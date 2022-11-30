
-> main

=== main ===
Hey little crow, what is your favorite bird?
    + [I like crows]
        -> chosen("crows")
    + [I like parrots]
        -> chosen("parrots")
    + [I like kiwis]
        -> chosen("kiwis")
        
=== chosen(chosenBird) ===
You chose {chosenBird}! That is also my favorite.
-> END