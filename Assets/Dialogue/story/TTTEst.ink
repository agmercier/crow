
-> main

=== main ===
Thank you, little crow. You got me my voice back!
    + [You're welcome!]
        -> chosen("cool")
    + [Get out of my way.]
        -> chosen("rude")
        
=== chosen(chosenBird) ===
You're very {chosenBird}... 

Anyway, what brings you out here?
	+ [I'm looking for my mom.]
		-> chosen("mom")

=== chosen(option) ===
Your {option} huh? I saw a crow not too long ago, heading into the cave to the east.
Maybe that was her?
-> END