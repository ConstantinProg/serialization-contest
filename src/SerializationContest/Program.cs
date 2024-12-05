using SerializationContest.PerformanceTests;

var testBench = new TestBench();

IPerformanceTest[] testCollection = [
    new CustomCsvSerializationTest(),
    new CustomCsvDeserializationTest(),
    new SystemTextJsonSerializationTest(),
    new SystemTextJsonDeserializationTest()];

foreach (var test in testCollection)
    Console.WriteLine(testBench.TestPerformance(test));


