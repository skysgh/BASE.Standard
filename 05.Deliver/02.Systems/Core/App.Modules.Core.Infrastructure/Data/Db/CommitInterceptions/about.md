# About #

When DbContexts - that inherit from the the default provided Module specific Base DbContext -
are saved, the objects they are saving are iterated over and filled in for any missing gaps
(eg: objects that implement an interface for Traceability of who changed what, are filled in
with the current time and name of the person making the change, and what change they are making).

