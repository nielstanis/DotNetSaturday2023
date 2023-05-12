
string input = "/temp/test.txt";
string output = "./copied.txt";
if (System.IO.File.Exists(output)) System.IO.File.Delete(output);

Wasmtime.WasiConfiguration conf = new Wasmtime.WasiConfiguration()
    .WithEnvironmentVariable("input-file", input)
    .WithEnvironmentVariable("output-file", output)
    .WithPreopenedDirectory("/temp", "/temp")
    .WithPreopenedDirectory("./","./")
    .WithInheritedStandardOutput();

var engineConfig = new Wasmtime.Config();
//engineConfig.WithFuelConsumption(true);
var engine = new Wasmtime.Engine(engineConfig);
var linker = new Wasmtime.Linker(engine);
linker.DefineWasi();
var store = new Wasmtime.Store(engine);
//store.AddFuel(1050000000);
store.SetWasiConfiguration(conf);

string wasm = @"../guest/bin/Debug/net7.0/guest.wasm";
var module = Wasmtime.Module.FromFile(engine, wasm);
var inst = linker.Instantiate(store, module);
var start = inst.GetFunction("_start");

Console.WriteLine("Host executing...");

try
{
    if (start != null)
        start.Invoke();
}
catch (Wasmtime.WasmtimeException)
{
    //Intentionally left blank
}

if (System.IO.File.Exists(output))
{
    Console.WriteLine($"Output file written '{output}'");
}
else
{
    Console.WriteLine($"Output file not written '{output}'");
}

//Console.WriteLine($"Fuel: {store.GetConsumedFuel()}");