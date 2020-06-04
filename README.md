# JPCodes.Extensions
C# Extensions

Enumerables:
```
//Similar to SQL IN
bool exists = "this".In<string>("exists, "in", "this");

//Union overload that takes params T[]
IEnumerable<int> unioned = new int[] { 1, 2, 3 }.Union<int>(4, 5, 6);

//Recursively dig through enumerables of enumerables, recovering T
List<int[]> multiArray = new List<int[]>();
IEnumerable<int> allItems = multiArray.Summon<int>();

//Enumerables start with the same items using the default comparison
int[] first = new int[3] { 0, 1, 2 };
List<int> second = new List<int> { 0, 1, 2 };
bool startsWith = first.StartsWith(second);

//Mathematical choose N
int[] chooseMe = new int[4] { 0, 1, 2, 3 };
IEnumerable<int[]> chosen = chooseMe.Choose(2);
// [0, 1], [0, 2], [0, 3], [1, 2], [1, 3], [2, 3]
```

Exceptions:
```
try
{
    ...
}
catch (Exception ex)
{
    //Get a prettier string of an exception. Useful for logging.
    string logMe = ex.Print();
    ...
}
```

String Parsing:
```
string val = "1";
int actual = val.ToInt().Value;

string gVal = "91048bc3-5a4b-4e9e-980c-69c2e8fad7fe";
Guid gActual = gVal.ToGuid().Value;

//ToBool
//ToDecimal
//ToLong
//ToDateTime
```
