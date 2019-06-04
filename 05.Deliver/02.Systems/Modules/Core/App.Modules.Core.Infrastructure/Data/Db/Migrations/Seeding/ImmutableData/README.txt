# About #

The difference between Immutable and Mutable data seeding is
that Immutable Data is part of the model and is invoked when
Migrations are applied.

Mutable data (eg: Demo data) is conditionally applied at some
later point (eg: when triggered via a controller action if 
so desired, , or a config setting).
