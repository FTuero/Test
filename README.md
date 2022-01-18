# Test

This document contains information about some taken decisions.

- You can use GET, PUT or POST to read, create or update a person if you want to do any test.    
- DELETE Ticket actions will delete its associated notes.   
- Audit.WebApi.Core has been chose to implement the tracking system.
  A JSON file should be create the first time when actions are made over a ticket.  
- Anyone can do GET, PUT or POST Note actions independly if that ticket belongs to person who creates the note. 
  A removed note by someone who is not a admin is a POST action with a boolean property called Passive. 
  An admin can DELETE a note.