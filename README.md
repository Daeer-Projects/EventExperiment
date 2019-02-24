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

---

## What else

As I have been working on experimenting with the event systems in C#, I have come to find, that the tools / packages out there are pretty good.

I have come up with a couple of ideas to help me improve my knowledge.

1. Create my own EasyHub.  All I need to do, is have something that registers the subscribers, and calls each of them when a publish event happens.  What could possibly go wrong? :)

2. Using the messaging types I have used, why not create a simple adventure game to use the messaging types?  Should be fun.