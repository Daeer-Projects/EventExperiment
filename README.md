# EventExperiment

As experiment with Events using the Pub/Sub pattern - I think!

## Introduction

This is a simple event system, that raised transactional events that are then consumed by other subscribers to the events.

### Publishers

* CustomerPublisher
* SitePublisher
* TransactionRegistration

### Subscribers

* CustomerSubscriber
* LogSubscriber
* SiteSubscriber

### Event Arguments

#### CustomerFoundEventArgs

This event is for when a customer has been found for the transaction.

#### LogReceivedEventArgs

This event is using serilog to log the details of the events that the logger subscribes to.  Overkill, I know, but I wanted to experiment with something that is used in most of the other publishers and subscribers.

#### SiteFoundEventArgs

This event is for when a site has been found for the transaction.

#### TransactionRegistrationEventArgs

This event is the main event.  It starts off the other events.

### PipelineConfiguration

This sets up all of the publishers and subscribers.  It uses some extension methods to register the publishers and subscribers.

## Program

This is a simple console application that generates 1000 transactions, processes them, and logs what has been done.

### Logger

I am using serilog in this application.

It generates a csv file that can be sorted by any of the columns.  The program generates a ```Guid()``` that is referenced in all of the logs.