
-> main

=== main ===
Thank you, little crow. You got me my voice back! (Press space to choose)
    + [You're welcome!]
        -> chosen("cool")
    + [Get out of my way.]
        -> chosen("rude")
        
=== chosen(chosenBird) ===
You're very {chosenBird}... 
-> END