# HadasimTest-ExerciseOne

# Projet description
This project reads from a files the most common names and their level of frequency and a list of identical names.
It reads them into a Dictionaries and sends them to a function that merge the identical names.
This function create a list of lists, and any list within the main list keeps the identical names.
After the merging the system calls to a function that sums the total number of occurrences per name.
the system returns as output the record of the names and their true frequency.

The files should be located in the next path: "D:\Files", with the names: Names, Synonyms.


# Example
The input files will look like this:
Names:
Jacob 15
Yaakov 12
Tomer 13
Yaacov 1
Tommer 4
Sara 19
Tomi 2
cobi 3
Synonyms:
Jacob Yaakov
Yaakov Yaacov
Tomer Tommer
cobi Jacob
Tomi Tommer

The output of the system:
Jacob - 31
Tomer - 19
Sara - 19
