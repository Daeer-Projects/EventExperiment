# EventExperiment

As experiment with Events using the Pub/Sub pattern - I think!

## Introduction

This is a simple event system, that raised transactional events that are then consumed by other subscribers to the events. I am going to make several solutions to show the different ways of making events work.

## Solutions

* EventExperiment-Basic.
  Just the first experiment to see how it works.

* EventExperiment-Services.
  Another experiment, but keeping the Pub/Sub in the same class, pretending to be a service.

* EventExperiment-EasyHub.
  Another experiment, the same as the services, but I found something that seems to be easier to set up and use.
  So, I'll continue with what I was doing in the Services version, but using this easy message hub.
  Performance is the same or slightly better than the Services version.
