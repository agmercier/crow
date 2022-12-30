-> main

=== main ===
My baby is that... 
Is that you?
What are you doing here?
    + [I came to save you!]
        -> chosen("You know how to get us out?")
    + [I don't know, can we go home?]
        -> chosen("You want to go home?")
        
=== chosen(option) ===
{option}
We need a current of air to go up, but this rock is in the way ever since the water stopped flowing.
If only there was a way to move it...
-> END