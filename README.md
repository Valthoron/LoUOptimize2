LoUOptimize2
============
Lord of Ultima was a browser-based multiplayer strategy game by Electronic Arts that ran from 2010 to 2014. The aim was, basically, to found cities, gather resources, build armies and ally with other players in defeating other alliances.

The four kinds of resources, wood, stone, iron and food, were produced by certain buildings inside cities, and they did so at a certain rate of resources per hour. This rate could be increased by two options:

1) Place the resource building next to natural resources that were generated randomly around the city when it was founded. These natural resources may be removed by the player, but cannot be created or relocated. Once removed, they were gone forever. A resource building may benefit from multiple natural resources, should they exist.

2) Build another type of building next to the resource building. A resource building may benefit from this only once. This kind of building, if build next to a storage building, also increases the amount of resource that can be stockpiled in the city.

Combined with the fact that the city layout was irregular and divided by walls, and there was a limit to the number of buildings in each city, optimizing resource generation and storage (which was obligatory if one wanted to be competitive in the game) became quite a complex problem.

LoU Optimizer uses a genetic algortihm in an attempt to find an optimal building placement that conforms to certain criteria for a city. It is possible to specify natural resources in the city, prefer production of certain resources (fixed amount or as much as possible) or increase resource storage. Certain buildings or empty plots may be locked on the map, if desired.

I built the optimizer to understand how genetic algorithms work. I would like to open this to other people so they can inspect and understand a genetic algorithm implementation that more or less works. I hope it will be helpful to someone. Please bear in mind that the project was done during a two-week vacation and was never intended to be published or perfected, therefore errors and bad coding practices may exist.

All copyrights belong to their respective owners. I am not affiliated with EA or LoU in any way.
