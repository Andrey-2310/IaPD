package execution;

import printer.Printer;

public class Application {

    private final static Executor executor = new Executor();
    private final static Printer printer = new Printer();

    public static void main(String[] args) throws  Exception{
        printer.print(executor.execute());
    }
}
