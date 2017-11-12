package execution;

import model.Hdd;
import model.MemoryStatus;

import java.io.File;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.nio.charset.Charset;
import java.util.Scanner;

public class Executor {
    private final static String command = "sudo hdparm -I /dev/sda";

    private final static String ataPattern = "Supported:";

    private final static String firmwarePattern = "Firmware Revision:";

    private final static String memoryAccessDmaPattern = "DMA:";

    private final static String memoryAccessPioPattern = "PIO:";

    private final static String modelPattern = "Model Number:";

    private final static String serialPattern = "Serial Number:";

    Hdd execute() throws IOException {
        final Process p = Runtime.getRuntime().exec(command);
        final Hdd hdd = parse(p.getInputStream());
        p.destroy();
        hdd.setMemoryStatus(getMemoryStatus());
        return hdd;
    }

     private MemoryStatus getMemoryStatus() {
        final MemoryStatus memoryStatus = new MemoryStatus();
        final File drive = new File("/");
        final Long free = drive.getFreeSpace();
        final Long total = drive.getTotalSpace();
        memoryStatus.setUsed(total-free);
        memoryStatus.setTotal(total);
        memoryStatus.setFree(free);
        return memoryStatus;
    }

    private Hdd parse(final InputStream is) {
        final Hdd hdd = new Hdd();
        try (Scanner scanner = new Scanner(new InputStreamReader(is, Charset.defaultCharset()))) {
            while (scanner.hasNext()) {
                final String line = scanner.nextLine();

                if (line.contains(ataPattern) && !line.contains("Enabled")) {
                    hdd.setAta(line.replace(ataPattern, "").trim());

                } else if (line.contains(firmwarePattern)) {
                    hdd.setFirmware(line.replace(firmwarePattern, "").trim());

                } else if (line.contains(memoryAccessPioPattern)) {
                    hdd.getMemoryAccess().setPio(line.replace(memoryAccessPioPattern, "").trim());

                } else if (line.contains(memoryAccessDmaPattern)) {
                    hdd.getMemoryAccess().setDma(line.replace(memoryAccessDmaPattern,"").trim());

                } else if (line.contains(modelPattern)) {
                    hdd.setModel(line.replace(modelPattern, "").trim());

                } else if (line.contains(serialPattern)) {
                    hdd.setSerial(line.replace(serialPattern, "").trim());
                }
            }
            scanner.close();
        }
        return hdd;
    }
}
