# LogMonitoringApp

App that analyse a csv with job events and produce a result file
that logs warnings or errors for jobs based on the duration of a job.

Logic flow:
 1) Read and parse job events from provided csv file
	* Create an in-memory model (object) of the job events provided in the file.
 2) Process job events and produce job logs
	* Separate Start and End events.
	* For each End event search for the coresponding Start event and calculate the duration of the job.
	* Create a job log if the duration is over 10 or 5 minutes ( eorror / warning ).
 3) Write the job logs in a new csv file
	* Write job log models (objects) in a csv format in a new result file.

Error handling sepparatley for every point inside logic flow.
Nugget packages used: CsvHelper - help with mapping between csv file and models

Testing: Manual testing.
	
Things that I would like to imporve: 
  a) Establish a global location for the csv file to be read/written from and use a setting for its path.
  b) Improve error handling and edge cases. (jobs without START/END event, no jobs in csv).
  b) Add unit tests in order to always check the integrity of app.
  c) Add a data base and save the job events and job log. 
  d) Convert app intro a microservices and recieve and respond with the csv files inside htpp requests or message queues.
  e) Convert to a proper DDD structure (Aplication, Domain, Infrastructure layers).
  f) Improve security via authentication and authorization.
  
