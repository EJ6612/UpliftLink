using AuthenticationServices;

namespace UpliftLink
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void myButton_Clicked(object sender, EventArgs e)
        {
        }

        private void ShuffleUserNameBtn_Clicked(object sender, EventArgs e)
        {
            string[] funAdjectives =
            {
                "Adventurous", "Amazing", "Ambitious", "Amusing", "Astounding", "Awesome", "Baffling", "Beautiful", "Bewildering", "Blissful",
                "Bouncy", "Brave", "Brilliant", "Bubbly", "Bumpy", "Calm", "Charming", "Cheerful", "Chipper", "Chirpy",
                "Clever", "Colorful", "Comical", "Confident", "Courageous", "Cozy", "Creative", "Curious", "Daring", "Dazzling",
                "Delicate", "Delightful", "Dynamic", "Eager", "Ecstatic", "Effervescent", "Electric", "Enchanting", "Energetic", "Exciting",
                "Exhilarating", "Fabulous", "Fantastic", "Fearless", "Festive", "Flamboyant", "Fluffy", "Friendly", "Funny", "Gallant",
                "Gigantic", "Gleaming", "Glorious", "Gorgeous", "Graceful", "Grateful", "Great", "Happy", "Harmonious", "Heroic",
                "Hilarious", "Honest", "Hopeful", "Hyper", "Imaginative", "Impressive", "Incredible", "Ingenious", "Inspiring", "Invincible",
                "Jazzy", "Jolly", "Jovial", "Joyful", "Jubilant", "Keen", "Kind", "Lively", "Lucky", "Luminous",
                "Majestic", "Marvelous", "Merry", "Mighty", "Miraculous", "Mischievous", "Musical", "Nifty", "Nimble", "Noble",
                "Optimistic", "Outstanding", "Peaceful", "Perky", "Playful", "Powerful", "Precious", "Proud", "Quick", "Radiant",
                "Remarkable", "Resilient", "Robust", "Sassy", "Savvy", "Shiny", "Silly", "Smart", "Smooth", "Sparkling",
                "Spectacular", "Speedy", "Splendid", "Spunky", "Steady", "Strong", "Stunning", "Superb", "Swanky", "Sweet",
                "Talented", "Terrific", "Thrilling", "Tranquil", "Unique", "Upbeat", "Vibrant", "Victorious", "Vivacious", "Vivid",
                "Whimsical", "Wise", "Witty", "Wonderful", "Wondrous", "Zany", "Zesty", "Zealous", "Absurd", "Astonishing",
                "Bashful", "Bizarre", "Blazing", "Breezy", "Brisk", "Bubbly", "Chirpy", "Chunky", "Clever", "Cool",
                "Crafty", "Crazy", "Cuddly", "Curious", "Dandy", "Dapper", "Daring", "Dazzling", "Dizzy", "Doodle",
                "Dreamy", "Droll", "Droopy", "Eager", "Effortless", "Energetic", "Excited", "Fantastic", "Fidgety", "Fierce",
                "Flaky", "Flamboyant", "Flashy", "Flawless", "Flimsy", "Fluffy", "Frisky", "Funny", "Fuzzy", "Giddy",
                "Giggly", "Gleeful", "Glowing", "Golden", "Goofy", "Graceful", "Gracious", "Grumpy", "Handy", "Happy-go-lucky",
                "Hasty", "Hilarious", "Hoppy", "Hyper", "Inventive", "Jazzy", "Jittery", "Jolly", "Jovial", "Jumpy",
                "Kind-hearted", "Light-hearted", "Lively", "Loony", "Lovable", "Lucky", "Luminous", "Mellow", "Mischievous", "Moody",
                "Mysterious", "Nimble", "Nutty", "Optimistic", "Outlandish", "Perky", "Playful", "Pleasant", "Plucky", "Polished",
                "Quick-witted", "Quirky", "Radiant", "Remarkable", "Restless", "Saucy", "Savvy", "Scenic", "Shaky", "Shiny",
                "Shy", "Silly", "Simple", "Sincere", "Skilled", "Snappy", "Snazzy", "Sparkly", "Speedy", "Spicy",
                "Sprightly", "Squiggly", "Stellar", "Sunny", "Super", "Sweet", "Swift", "Talented", "Tender", "Ticklish",
                "Timid", "Tranquil", "Twinkling", "Unique", "Upbeat", "Vibrant", "Whacky", "Whimsical", "Wily", "Witty",
                "Wonderful", "Zany", "Zealous", "Zesty", "Amiable", "Affectionate", "Approachable", "Awesome", "Balanced", "Benevolent",
                "Blissful", "Brave", "Bright", "Brilliant", "Bubbly", "Candid", "Capable", "Charming", "Cheerful", "Compassionate",
                "Confident", "Considerate", "Courageous", "Courteous", "Dazzling", "Diligent", "Diplomatic", "Dynamic", "Efficient", "Empathetic",
                "Encouraging", "Energetic", "Engaging", "Entertaining", "Enthusiastic", "Excited", "Exuberant", "Fabulous", "Fair", "Faithful",
                "Fantastic", "Fascinating", "Fearless", "Flexible", "Friendly", "Fun", "Funny", "Generous", "Gentle", "Genuine",
                "Good-natured", "Gracious", "Happy", "Hardworking", "Helpful", "Honest", "Hopeful", "Imaginative", "Impressive", "Incredible",
                "Inspiring", "Intelligent", "Inventive", "Joyful", "Jubilant", "Keen", "Kind", "Light-hearted", "Lively", "Loyal",
                "Lucky", "Magnetic", "Magnificent", "Marvelous", "Motivated", "Nifty", "Observant", "Optimistic", "Organized", "Outgoing",
                "Passionate", "Patient", "Peaceful", "Persistent", "Playful", "Polite", "Positive", "Powerful", "Proactive", "Productive",
                "Radiant", "Reliable", "Resilient", "Resourceful", "Responsible", "Sincere", "Skilled", "Spirited", "Spunky", "Steady",
                "Strong", "Supportive", "Sympathetic", "Talented", "Thoughtful", "Tidy", "Trustworthy", "Understanding", "Unique", "Upbeat",
                "Vibrant", "Vivacious", "Warm", "Willing", "Wise", "Wonderful", "Zany", "Zealous", "Zesty", "Zippy",
                "Adorable", "Adventurous", "Aggressive", "Agreeable", "Alert", "Aloof", "Amiable", "Amused", "Anxious", "Apathetic",
                "Artistic", "Assertive", "Attentive", "Attractive", "Average", "Bashful", "Belligerent", "Bewildered", "Blissful", "Boisterous",
                "Bold", "Bored", "Bossy", "Brave", "Bright", "Brilliant", "Busy", "Calm", "Carefree", "Careful",
                "Careless", "Cautious", "Charming", "Cheerful", "Chilled", "Chipper", "Classy", "Clever", "Clumsy", "Comical",
                "Compassionate", "Confident", "Confused", "Considerate", "Content", "Cooperative", "Courageous", "Courteous", "Cranky", "Creepy",
                "Critical", "Curious", "Dainty", "Daring", "Dashing", "Defensive", "Delightful", "Demanding", "Dependable", "Depressed",
                "Determined", "Devoted", "Diligent", "Discreet", "Disgruntled", "Disorganized", "Disrespectful", "Distracted", "Dizzy", "Dramatic",
                "Dreamy", "Driven", "Drowsy", "Dynamic", "Eager", "Easygoing", "Ecstatic", "Effervescent", "Efficient", "Elated",
                "Elegant", "Energetic", "Enthusiastic", "Envious", "Excited", "Exuberant", "Fabulous", "Faithful", "Fancy", "Fantastic",
                "Fascinating", "Fearless", "Feisty", "Fickle", "Friendly", "Funny", "Furious", "Generous", "Glamorous"
            };

            string[] funNouns = 
            {
                "Aardvark", "Abacus", "Accordion", "Acorn", "Aerosol", "Airplane", "Albatross", "Almond", "Anchor", "Angler",
                "Antelope", "Apocalypse", "Apple", "Apricot", "Armchair", "Arrow", "Armadillo", "Avocado", "Baboon", "Backpack",
                "Badger", "Bagpipe", "Baguette", "Ballerina", "Balloon", "Banana", "Bandana", "Barbecue", "Barnacle", "Barracuda",
                "Basketball", "Bathtub", "Beachball", "Beaver", "Beehive", "Beetle", "Bicycle", "Blender", "Blizzard", "Bobsled",
                "Boombox", "Bowling", "Breadstick", "Broccoli", "Bubble", "Buffalo", "Bumblebee", "Cactus", "Camel", "Candy",
                "Canoe", "Cantaloupe", "Capybara", "Carnival", "Carrot", "Cassette", "Catapult", "Caterpillar", "Catfish", "Caveman",
                "Chainsaw", "Chameleon", "Cheeseburger", "Chimney", "Chocolate", "Coconut", "Comet", "Compass", "Concertina", "Cookie",
                "Cowboy", "Crayon", "Crocodile", "Cucumber", "Cupcake", "Cyclone", "Dandelion", "Dartboard", "Daydream", "Deer",
                "Dinosaur", "Djembe", "Donut", "Dragon", "Drumstick", "Duckling", "Dumpster", "Eagle", "Earthquake", "Eggplant",
                "Elephant", "Elk", "Emu", "Escalator", "Eucalyptus", "Ferry", "Firecracker", "Firefly", "Firetruck", "Fishing",
                "Flamingo", "Flashlight", "Fleabag", "Flowerpot", "Football", "Fountain", "Frisbee", "Frolic", "Frostbite", "Fruitcake",
                "Galaxy", "Gazelle", "Gecko", "Geyser", "Giraffe", "Glacier", "Glider", "Goat", "Gondola", "Gorilla",
                "Grapes", "Greenhouse", "Guacamole", "Guitar", "Hammock", "Hamster", "Helicopter", "Hippopotamus", "Honeybee", "Hotdog",
                "Hummingbird", "Hurricane", "Icicle", "Igloo", "Iguana", "Jackhammer", "Jaguar", "Jellyfish", "Jigsaw", "Joystick",
                "Jumpingjack", "Jungle", "Kangaroo", "Kettle", "Kiwi", "Koala", "Ladder", "Ladybug", "Lamborghini", "Landslide",
                "Lawnmower", "Lemonade", "Lighthouse", "Lobster", "Lollipop", "Macaroni", "Machete", "Magician", "Mango", "Manta",
                "Marathon", "Marshmallow", "Meadow", "Megaphone", "Melon", "Mermaid", "Meteor", "Microscope", "Milkshake", "Minotaur",
                "Moose", "Mosquito", "Motorcycle", "Mountain", "Mushroom", "Narwhal", "Nebula", "Ninja", "Noodle", "Octopus",
                "Omelette", "Ostrich", "Otter", "Owl", "Pancake", "Parachute", "Parrot", "Peacock", "Pencil", "Penguin",
                "Pepperoni", "Periscope", "Picnic", "Pineapple", "Pirate", "Platypus", "Popcorn", "Porcupine", "Popsicle", "Postcard",
                "Puffin", "Pumpkin", "Puppet", "Puzzle", "Pyramid", "Quagmire", "Quicksand", "Quokka", "Rabbit", "Raccoon",
                "Raindrop", "Rainbow", "Rattlesnake", "Ravioli", "Reindeer", "Rhino", "Rocket", "Rollercoaster", "Rugby", "Sandcastle",
                "Saxophone", "Scarecrow", "Scooter", "Seagull", "Seahorse", "Shark", "Shoelace", "Skateboard", "Skyscraper", "Slingshot",
                "Snowball", "Snowman", "Spaceship", "Spaghetti", "Sphinx", "Spider", "Squirrel", "Starfish", "Stethoscope", "Submarine",
                "Sugarcube", "Sunflower", "Sundial", "Sunset", "Swan", "Sweater", "Swing", "Swordfish", "Tambourine", "Tank",
                "Teacup", "Telescope", "Throne", "Thunderstorm", "Tiger", "Toadstool", "Tornado", "Trampoline", "Treasure", "Trombone",
                "Tsunami", "Tugboat", "Turtle", "Ukulele", "Umbrella", "Unicorn", "Vacuum", "Valentine", "Vampire", "Velociraptor",
                "Volcano", "Walrus", "Waterfall", "Watermelon", "Whale", "Wheelbarrow", "Windmill", "Wizard", "Wombat", "Xylophone",
                "Yacht", "Yak", "Yo-yo", "Zebra", "Zeppelin", "Zucchini", "Accordionist", "Aloe", "Anteater", "Armadillo",
                "Ashtray", "Asparagus", "Astronaut", "Backpack", "Bagel", "Ballerina", "Banana", "Barbell", "Barn", "Basket",
                "Bat", "Beach", "Bear", "Beard", "Bed", "Bee", "Beetle", "Bicycle", "Bingo", "Bison",
                "Blackboard", "Blanket", "Boat", "Bomb", "Book", "Boomerang", "Bottle", "Boxer", "Bridge", "Broom",
                "Bucket", "Buffalo", "Bug", "Bulldozer", "Bunny", "Butterfly", "Cabin", "Cake", "Calendar", "Candle",
                "Cannon", "Car", "Carrot", "Castle", "Cat", "Chair", "Chalk", "Cheese", "Chick", "Chicken",
                "Chipmunk", "Chisel", "Cinnamon", "Circus", "Clam", "Cliff", "Clock", "Clown", "Cloud", "Coconut",
                "Coin", "Comb", "Computer", "Cookie", "Crab", "Creeper", "Cricket", "Crocodile", "Crown", "Cup",
                "Curtain", "Daffodil", "Daisy", "Dandelion", "Dinosaur", "Disco", "Dog", "Doll", "Donkey", "Door",
                "Dragonfly", "Dresser", "Duck", "Easel", "Echo", "Egg", "Elevator", "Elm", "Engine", "Envelope",
                "Eraser", "Factory", "Fan", "Feather", "Ferriswheel", "Fish", "Flamingo", "Flashlight", "Flower", "Foot",
                "Fountain", "Fox", "Frog", "Furnace", "Galaxy", "Garage", "Garden", "Gate", "Ghost", "Giraffe",
                "Glacier", "Glove", "Goggles", "Golf", "Goose", "Gorilla", "Grass", "Gravy", "Grill", "Guitar",
                "Gymnast", "Hammer", "Handbag", "Harbor", "Harmonica", "Hat", "Hawk", "Helium", "Helm", "Hen",
                "Hippopotamus", "Hobbit", "Horse", "Hotdog", "House", "Hummingbird", "Hut", "Iceberg", "Iguana", "Ink",
                "Iron", "Island", "Jackal", "Jacket", "Jar", "Jelly", "Jumper", "Kale", "Kangaroo", "Kettle",
                "Kite", "Kitten", "Koala", "Ladder", "Ladybug", "Lake", "Lamp", "Lawn", "Leaf", "Leopard",
                "Library", "Lion", "Lizard", "Llama", "Lock", "Lollipop", "Lumberjack", "Magnet", "Mammoth", "Maple",
                "Marker", "Mars", "Matchbox", "Meerkat", "Microphone", "Milk", "Minivan", "Mirror", "Moat", "Monk",
                "Monkey", "Moose", "Mop", "Mosquito", "Mountain", "Mouse", "Muffin", "Mushroom", "Nest", "Net",
                "Noodle", "Nut", "Oasis", "Oat", "Octopus", "Onion", "Orange", "Orca", "Oven", "Ox",
                "Paddle", "Palace", "Panda", "Pansy", "Paper", "Parrot", "Peach", "Peacock", "Peanut", "Penguin",
                "Pepper", "Piano", "Pickle", "Pig", "Pillow", "Pine", "Pizza", "Planet", "Platypus", "Plow",
                "Pony", "Popcorn", "Puddle", "Puffin", "Pumpkin", "Purse", "Quail", "Queen", "Quilt", "Rabbit",
                "Raccoon", "Rain", "Raven", "Reef", "Robot", "Rocket", "Rose", "Sailboat", "Sardine", "Scarf",
                "Scissors", "Scooter", "Seal", "Sheep", "Ship", "Skirt", "Sloth", "Snail", "Snake", "Sneeze",
                "Snowflake", "Spider", "Spoon", "Squid", "Squirrel", "Star", "Steamboat", "Stegosaurus", "Stone", "Subway",
                "Suitcase", "Sun", "Sword", "Taco", "Teapot", "Telephone", "Tiger", "Toaster", "Toilet", "Tomato",
                "Towel", "Train", "Trombone", "Trumpet", "Turtle", "Umbrella", "Unicorn", "Vacuum", "Vampire", "Van",
                "Vase", "Vegetable", "Violin", "Volcano", "Walnut", "Walrus", "Wand", "Wasp", "Water", "Weasel",
                "Wheel", "Whistle", "Wolf", "Wombat", "Xylophone", "Yacht", "Yak", "Yarn", "Yeti", "Zebra", "Mormon",
                "Nephite"
            };

            Random random = new Random();

            string userAdjective = funAdjectives[random.Next(funAdjectives.Length)];
            string userNoun = funNouns[random.Next(funNouns.Length)];

            int userNumber = random.Next(1000, 10000);

            string userName = $"{userAdjective}-{userNoun}-{userNumber}";

            userNameBox.Text = userName;
        }
    }

}
