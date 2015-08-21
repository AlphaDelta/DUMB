# DUMB

Dont Underestimate My Bongos, a fast (read: not secure) ransomware proof of concept.

<img src="https://i.imgur.com/pl2CZJQ.png" />

## How do I test it?
Create a folder in My Documents with the name 'TEST' and throw any files you don't like in there; homework, bills, whatever. Compile and run the program and your files will be encrypted using an XOR pad generated via the ISAAC CSPRNG.

Seriously throw whatever you want in there DUMB uses streams so it should be able to handle files larger than 4GB, my i5-3230M reaches 50MiB/s and uses no more than 2.3MB of memory regardless of file size.

## I'm trapped in desktop limbo somehow, how do I get out?

If a 'Crypt' window is visible right click on the progress bar and click 'Yes' in the dialog box, that should close the window and fix the flow of the program.

If a 'Main' window is visible right click on the lock in the image on the left to enable the 'Decrypt' button (in the event somehow you managed to screw up the didgeridoo exchange).

If however no windows are visible you'll have to try and shutdown your computer and hope to god some process on your regular desktop hangs the shutdown long enough for you to cancel it (same thing goes with Windows 7).

## How do I report a problem?
Trick question, I don't care about your problems.

## This is dumb.
First of all that's not a question and second of all yes this *is* DUMB.