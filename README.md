[![Unit Tests CI Status](https://github.com/Bilal44/numeral-converter/actions/workflows/ci.yml/badge.svg)](https://github.com/Bilal44/numeral-converter/actions/workflows/ci.yml)

# Roman Numeral Converter
Contrary to my initial assumption, it was quite an enjoyable exercise, especially going through the validation rules. It was also interesting to read on Wikipedia how numbers like IIII, XXXX, CCCCLXXXX were historically used but will now be considered completely invalid. I have been exploring the rules further on [Project Euler](https://projecteuler.net/about=roman_numerals). I might find some time to fully implement all of it one day. :)

## Design Approach
- Some samples were already provided in the task brief, which made it quite easy to develop using [**TDD (Test-Driven Development)**](https://martinfowler.com/bliki/TestDrivenDevelopment.html).
- I kept the classes and methods static, it would likely to be a utility class in a real-world scenario anyway.
- ~~I _really_ wanted to used unsigned numbers and started with `ushort`, but handling exceptions for negative numbers was a bit too much. I still opted for `short` over `int`, where else would I ever know that the number would always be this small!~~ I updated it to `int`, just in case.
- I started with a dictionary because it seems very logical for key-value pairs. However, dictionaries can't guarantee order apart from `IOrderedDictionary`, even though all the test were passing. I found out about the obscure `ListDictionary` too that is ideal for 10 or less items. I went with the simplest solution, which would also be the most performant one since it is never likely to change during runtime. A fixed sized array with no hashing or linked lists involved, ideal for static look-up tables.

## Bonus: Element Symbol Searcher
I was really curious about the other test, so I decided to do some research and found some relevant results. Since I haven't been able to find the exact task brief, I modelled it after [Chemical Element Words website](https://periodictable.chemicalaid.com/fun/spell-words-with-elements.php?word=opinion).

At first, searching using a basic recursive algorithm was logical and it did achieve the expected results. But as I experimented with more complex words like ***confession*** or ***consciousness***, I noticed a lot of repeated patterns like 3 x `C,O,N,S`, then 3 x `Co,N,Sc`. That led to memoised solution with storing and retrieving already explored _"paths"_ in a cache to avoid searching the entire periodic table over and over again.