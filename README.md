# Price Calculator

A virtual basket that can:

- have products added to it
- total the cost of the products that it contains
- have discounts applied to the total

The basket is a dotnet library written in C#, created as a coding exercise for MSMG.

---

Available products:
- Butter  - £0.80
- Milk    - £1.15
- Bread   - £1.00

Available offers:
- Buy 2 Butter and get a Bread at 50% off
- Buy 3 Milk and get the 4th milk for free

Given scenarios:
- Given the basket has 1 bread, 1 butter and 1 milk when I total the basket then the total should be £2.95
- Given the basket has 2 butter and 2 bread when I total the basket then the total should be £3.10
- Given the basket has 4 milk when I total the basket then the total should be £3.45
- Given the basket has 2 butter, 1 bread and 8 milk when I total the basket then the total should be £9.00

---

I will be using the given scenarios only for this exercise.

---

## Conclusion

I've not solved this problem since I first learnt TDD years ago, it was a good challenge. I did have a first attempt which I gave up on on the last test as I had strayed from a red, green, refactor cycle and introduced too many things that were not needed. However, I was able to have more of a think about the domain and start again, and have produced much better code as a result. I was not pleased with the spec from the start, as in my opinion, the basket is doing multiple things. This made it more difficult to have freedom with how a basket was used, and how the other abstractions should have interacted with it.

I would liked to have spoken with the product owner to clarify a few things before starting. It's important to get the use of domain language correct when writing the tests, as these are what will drive out the code, and with a concept not quite fully realised from the start, this can lead to creating a mess for yourself quite quickly. I don't write tests with the implementation in mind at all. I try to copy and paste from the spec into comments, and replace them with the simplest definitions that I can, before making them exist. I don't want to introduce new language if I can help it: our language is a very powerful thing, and every new word can mean multiple new abstractions without even realising it.

I'd have very much appreciated a pair to keep each other on track since this solution really is non-trivial. I find that pair programming boosts my productiving many, many times over. Often in the form of telling each other YAGNI. I have not gold plated this solution, I have some issues with the state that I have left it in. I thought it was perhaps more interesting to leave here and be able to talk about which code smells there are here and there: there aren't many times you can be more certain that there will be no more requirements!

Some examples of things I know that aren't perfect here (if only I had vs and r# as I write this):
- Product is having almost all of its methods called inside Offer
- No dependencies have been inverted
- Overloaded use of decimals: perhaps Money and Percentage should also be classes. ie. Can Money can be taxed? Could Offers could take "x amount off" reductions instead of percentages?
