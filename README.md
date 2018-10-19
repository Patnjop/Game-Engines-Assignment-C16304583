# Game Engines Assignment C16304583
## Civilisation generation
I plan to create a scene that begins with an unpopulated floodplains, after time the area will become populated and life will begin to thrive until it reaches it's climax in the form of a neon coloured urban area. I intend to use initial randomisation and/or player input followed by a sequence of rules to guide the progression of the simulation. I have taken inspiration from the world's most popular cellular automaton Conway's Game of Life, as well as games that utilise a specific set of rules to determine how certain parts interact with eachother like Dwarf Fortress.

![City Plan](https://cdn-images-1.medium.com/max/1600/0*dmAdV2GrWAIkNqa5.jpg)

## Rule System
The focus of the project will be on a rule system that runs well, I intend to have objects identify their surroundings and respond based on the result. Using this I plan to have the city grow based on a rule system that keeps track of the different variables within the sscene like, the amount of buildings concentrated in one area etc...

![Potential Layout](https://steemitimages.com/0x0/https://static.wixstatic.com/media/02f673_8db3f403779947e285d2ff2646d8e297~mv2.png/v1/fit/w_350,h_449,al_c,q_90/file.webp).

## Implementation
For the visuals I intend to follow an uncomplicated yet abstract style that is visually stimulating, my intention is to have several pre-built situations that if the circumstances are met cause exciting or impressive visuals. I will use a grid based system so that I can easily reference other grids, I will also be instantiating the buildings using several controller blocks. I intend to have small objects that will behave and move releative to their parent's orientation. The player will be able to alter the starting condition to examine the effect of increasing different variables such as the fertility of the soil or the starting population.

## References
[Guide to basic procedural city generation](https://www.youtube.com/watch?v=xkuniXI3SEE).

[Guide to making a hex map](https://catlikecoding.com/unity/tutorials/hex-map/part-1/).

[Tutorial for procedural generation](https://www.red-gate.com/simple-talk/dotnet/c-programming/procedural-generation-unity-c/).

[Unity Manual on Randomisation](https://docs.unity3d.com/Manual/RandomNumbers.html).

[Tutorial that covers Voxel terrain and Perlin noise](https://forum.unity.com/threads/tutorial-procedural-meshes-and-voxel-terrain-c.198651/).
