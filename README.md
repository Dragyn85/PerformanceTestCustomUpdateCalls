![alttext](https://img.shields.io/badge/Unity%20version-2021.3.16f1-lightgrey&?style=for-the-badge&logo=unity&color=lightgray)  ![alttext](https://img.shields.io/badge/License-MIT-lightgrey&?style=for-the-badge&color=green)  ![alttext](https://img.shields.io/badge/O.S-Windows%2010-lightgrey&?style=for-the-badge&color=purple)
# Performance Test Custom Update Calls
This is an extended version of my friend AlMartsons project about unity update calls that works fine with a few components to update, but as the component count grows the performance will suffer.
Main idea is to impliment an update manager who calls that update all your other scripts.
You must also remove the empty Update method inside the MonoBehaviours or they will still be called and slow down your project.

Taking control of your Updates this way is a good idea as you can easily extend the way your game is updated, you can for instance make more update methods with different intervals saving even more performance. This is a great step if you are not ready to start using Unity DOTS.

The "original project" was using an array of modified Monobehaviours that it cycles through with an for loop each update. The manager calls an update method on each element. Initially I wanted to try different approaches about the update manager for example using listeners.
But also decided to update it with diffrent tests and make it more easily extended.

Current tests:
- Unity Update
- Update manager with an Array
- Update manager with a delegate
- Update manager with a List and foreach loop
- Update manager with a List and for loop

Each manager updates a set amount of objects, all these updates do is increment an number, for 10 seconds.  
💻Test Pc Spec's:
CPU: Intel core I9 12600K
RAM: 64Gb DDR4-3733MHz

## Results and thoughts when testing with 10 000 and 50 000 updated gameobjects:
![Alt text](https://github.com/Dragyn85/PerformanceTestCustomUpdateCalls/blob/master/Pictures%20for%20ReadMe/Both%20together.png?raw=true "Title")
As expected the Unity update was slowest in execution but didnt take long to initialize.
Slightly slower initiation, only a few ms, the Array was about 67% faster than the prior test case with 10k objects and a 320% faster with 50k.

Roughly the same execution rate at 10 000 objects but alot slower initiation time for the delegate, 66ms vs 208ms, with 10k objects. With 50k objects the difference goes from 215% 730% and also start losing some FPS.

The List managers has same initiation time as the Array and the for loop managed one had only 10 less fps at 10k objects but 100 less at 50k objects.

My own conclusion is that the manager with an array wins all the perfromance tests but its gonna be a pain to manage an array if there are alot of gameobejects that are added / removed. 
In that scenario I would prefer a List most of the time, the Observer would also work if you are not trying to initiate alot of objects at the same time.

## How to use?
1. Download project
2. Open in Unity
3. Run it

Do you have your own test to that u want to creat?
1. Drag in the PresetUpdateTest from the prefab folder
2. Create a new gameobjec and add a c# script to be tested, make it inherit TestCase.
3. Add it to the Factorys "Object to Instanciate".
4. Add "SpawnedObjectContainer" to target transfrom in the factory.

Optional
1. If you want the initialize time to be measured correctly use TestCase's Setup function to set the gameobject up.
2. If the Manager needs some time to set up, create a "BoolValue" scriptable object from "create asset" menu and hook it up to the factory and your manager.


MIT License

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
