# DUMB

Dont Underestimate My Bongos, a fast (read: not secure) ransomware proof of concept.

<img src="https://i.imgur.com/pl2CZJQ.png" />

## How do I test it?
Create a folder in My Documents with the name 'TEST' and throw any files you don't like in there; homework, bills, whatever. Compile and run the program and your files will be encrypted using an XOR pad generated via the ISAAC CSPRNG.

Seriously throw whatever you want in there DUMB uses streams so it should be able to handle files larger than 4GB, my i5-3230M reaches 50MiB/s and uses no more than 2.3MB of memory regardless of file size.

## How do I report a problem?
Trick question, I don't care about your problems.

## This is dumb.
First of all that's not a question and second of all yes this *is* DUMB.