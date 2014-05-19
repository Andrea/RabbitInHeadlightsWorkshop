namespace TestExamples

open NUnit.Framework

module TestingSomething =

    [<Test>]
    let ``True is true``() = 
        Assert.True(true)

    [<Test>]
    let ``Reality``() =
        Assert.AreNotEqual(2,3)