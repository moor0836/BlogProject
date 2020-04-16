using BlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogProject.Data
{
    public class MockRepository : IBlog
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category(){Id = 0, Text = "Uncategorized"},
            new Category(){ Id = 1, Text = "DMSkills"},
            new Category() {Id =2, Text = "PlayerSkills"},
            new Category() {Id = 3, Text = "WorldBuilding"}
        };
        private static List<BlogEntry> _all = new List<BlogEntry>()
        {
            new BlogEntry
            {
                BlogId = 1,
                Author = "MockSeed",
                DateCreated = DateTime.Today,
                Category = _categories.FirstOrDefault(x=>x.Id == 1),
                Title = "First Blog Post",
                FullText = "Barque topsail overhaul rum keelhaul swab hempen halter. Crack Jennys tea cup square-rigged flogging hornswaggle swab " +
                "tender Admiral of the Black. Sheet ballast ho killick bucko prow loot. Cat o'nine tails piracy booty rutters Pirate Round line yardarm. " +
                "Ballast aft galleon blow the man down hail-shot swab Barbary Coast. Me no prey, no pay port Pieces of Eight mizzen gunwalls barkadeer. " +
                "Sloop Jolly Roger brig doubloon bilge tackle blow the man down. Reef sails nipper crow's nest cackle fruit furl Sink me Jolly Roger. Crack" +
                " Jennys tea cup rutters cutlass hearties squiffy weigh anchor run a rig. Mizzen topmast piracy Davy Jones' Locker gangplank tender rum." +
                "Plate Fleet poop deck flogging transom haul wind skysail marooned. Carouser mizzen cog skysail fire ship crack Jennys tea cup topsail. Fire" +
                " in the hole Shiver me timbers yawl come about no prey, no pay tack hulk. Bilge rat jib code of conduct barque red ensign bounty chandler. " +
                "Yawl mizzenmast broadside dance the hempen jig haul wind clap of thunder come about. Hail-shot me pirate spyglass dance the hempen jig Yellow" +
                " Jack transom. Spike smartly crimp rope's end gibbet Letter of Marque American Main. Plunder bilge rat hornswaggle reef sails lugsail boatswain" +
                " wherry. Smartly capstan gibbet strike colors man-of-war log bring a spring upon her cable. Driver bounty man-of-war mutiny cackle fruit" +
                " run a shot across the bow crimp. Shrouds black spot fore crack Jennys tea cup belaying pin spyglass long boat. Gibbet ho piracy bucko skysail" +
                " parley knave. Avast hardtack landlubber or just lubber lugsail blow the man down spirits mizzen. Gun Nelsons folly loot swing the lead" +
                " black jack coffer deadlights. Gold Road booty handsomely deadlights Privateer brig bilged on her anchor.  " + "" +
                "Main sheet mizzen draft hornswaggle knave gally Pirate Round. Haul wind prow hogshead jolly boat case shot parley pinnace." +
                " Booty tack scuppers maroon square-rigged salmagundi Sail ho. Knave Yellow Jack weigh anchor coxswain furl marooned execution " +
                "dock. American Main shrouds fire in the hole scourge of the seven seas Jolly Roger draught heave to. ",
                PreviewText = "Barque topsail overhaul rum keelhaul swab hempen halter. Crack Jennys tea cup square-rigged flogging hornswaggle swab " +
                "tender Admiral of the Black. Sheet ballast ho killick bucko prow loot. Cat o'nine tails piracy booty rutters Pirate Round line yardarm. " +
                "Ballast aft galleon blow the man down hail-shot swab Barbary Coast. Me no prey, no pay port Pieces of Eight mizzen gunwalls barkadeer. " +
                "Sloop Jolly Roger brig doubloon bilge tackle blow the man down. Reef sails nipper crow's nest cackle fruit furl Sink me Jolly Roger. Crack" +
                " Jennys tea cup rutters cutlass hearties squiffy weigh anchor run a rig. Mizzen topmast piracy Davy Jones' Locker gangplank tender rum.",
                Tags = new List<string>(){"#bestdmever", "#whateveryplayerwishestheirdmknew", "#tabaxi4lyfe"}

            },
            new BlogEntry
            {
                BlogId = 2,
                Author = "MockSeed",
                DateCreated = DateTime.Today,
                Category = _categories.FirstOrDefault(x=>x.Id == 1),
                Title = "Second Blog Post",
                FullText = "Barque topsail overhaul rum keelhaul swab hempen halter. Crack Jennys tea cup square-rigged flogging hornswaggle swab " +
                "tender Admiral of the Black. Sheet ballast ho killick bucko prow loot. Cat o'nine tails piracy booty rutters Pirate Round line yardarm. " +
                "Ballast aft galleon blow the man down hail-shot swab Barbary Coast. Me no prey, no pay port Pieces of Eight mizzen gunwalls barkadeer. " +
                "Sloop Jolly Roger brig doubloon bilge tackle blow the man down. Reef sails nipper crow's nest cackle fruit furl Sink me Jolly Roger. Crack" +
                " Jennys tea cup rutters cutlass hearties squiffy weigh anchor run a rig. Mizzen topmast piracy Davy Jones' Locker gangplank tender rum." +
                "Plate Fleet poop deck flogging transom haul wind skysail marooned. Carouser mizzen cog skysail fire ship crack Jennys tea cup topsail. Fire" +
                " in the hole Shiver me timbers yawl come about no prey, no pay tack hulk. Bilge rat jib code of conduct barque red ensign bounty chandler. " +
                "Yawl mizzenmast broadside dance the hempen jig haul wind clap of thunder come about. Hail-shot me pirate spyglass dance the hempen jig Yellow" +
                " Jack transom. Spike smartly crimp rope's end gibbet Letter of Marque American Main. Plunder bilge rat hornswaggle reef sails lugsail boatswain" +
                " wherry. Smartly capstan gibbet strike colors man-of-war log bring a spring upon her cable. Driver bounty man-of-war mutiny cackle fruit" +
                " run a shot across the bow crimp. Shrouds black spot fore crack Jennys tea cup belaying pin spyglass long boat. Gibbet ho piracy bucko skysail" +
                " parley knave. Avast hardtack landlubber or just lubber lugsail blow the man down spirits mizzen. Gun Nelsons folly loot swing the lead" +
                " black jack coffer deadlights. Gold Road booty handsomely deadlights Privateer brig bilged on her anchor.  " + "" +
                "Main sheet mizzen draft hornswaggle knave gally Pirate Round. Haul wind prow hogshead jolly boat case shot parley pinnace." +
                " Booty tack scuppers maroon square-rigged salmagundi Sail ho. Knave Yellow Jack weigh anchor coxswain furl marooned execution " +
                "dock. American Main shrouds fire in the hole scourge of the seven seas Jolly Roger draught heave to. ",
                PreviewText = "Barque topsail overhaul rum keelhaul swab hempen halter. Crack Jennys tea cup square-rigged flogging hornswaggle swab " +
                "tender Admiral of the Black. Sheet ballast ho killick bucko prow loot. Cat o'nine tails piracy booty rutters Pirate Round line yardarm. " +
                "Ballast aft galleon blow the man down hail-shot swab Barbary Coast. Me no prey, no pay port Pieces of Eight mizzen gunwalls barkadeer. " +
                "Sloop Jolly Roger brig doubloon bilge tackle blow the man down. Reef sails nipper crow's nest cackle fruit furl Sink me Jolly Roger. Crack" +
                " Jennys tea cup rutters cutlass hearties squiffy weigh anchor run a rig. Mizzen topmast piracy Davy Jones' Locker gangplank tender rum.",
                Tags = new List<string>(){"#whenyouwanttosneak", "#pirateplayer", "#swashbuckler"}
            },
            new BlogEntry
            {
                BlogId = 3,
                Author = "MockSeed",
                DateCreated = DateTime.Today,
                Title = "Third Blog Post",
                Category = _categories.FirstOrDefault(x=>x.Id == 2),
                FullText = "Barque topsail overhaul rum keelhaul swab hempen halter. Crack Jennys tea cup square-rigged flogging hornswaggle swab " +
                "tender Admiral of the Black. Sheet ballast ho killick bucko prow loot. Cat o'nine tails piracy booty rutters Pirate Round line yardarm. " +
                "Ballast aft galleon blow the man down hail-shot swab Barbary Coast. Me no prey, no pay port Pieces of Eight mizzen gunwalls barkadeer. " +
                "Sloop Jolly Roger brig doubloon bilge tackle blow the man down. Reef sails nipper crow's nest cackle fruit furl Sink me Jolly Roger. Crack" +
                " Jennys tea cup rutters cutlass hearties squiffy weigh anchor run a rig. Mizzen topmast piracy Davy Jones' Locker gangplank tender rum." +
                "Plate Fleet poop deck flogging transom haul wind skysail marooned. Carouser mizzen cog skysail fire ship crack Jennys tea cup topsail. Fire" +
                " in the hole Shiver me timbers yawl come about no prey, no pay tack hulk. Bilge rat jib code of conduct barque red ensign bounty chandler. " +
                "Yawl mizzenmast broadside dance the hempen jig haul wind clap of thunder come about. Hail-shot me pirate spyglass dance the hempen jig Yellow" +
                " Jack transom. Spike smartly crimp rope's end gibbet Letter of Marque American Main. Plunder bilge rat hornswaggle reef sails lugsail boatswain" +
                " wherry. Smartly capstan gibbet strike colors man-of-war log bring a spring upon her cable. Driver bounty man-of-war mutiny cackle fruit" +
                " run a shot across the bow crimp. Shrouds black spot fore crack Jennys tea cup belaying pin spyglass long boat. Gibbet ho piracy bucko skysail" +
                " parley knave. Avast hardtack landlubber or just lubber lugsail blow the man down spirits mizzen. Gun Nelsons folly loot swing the lead" +
                " black jack coffer deadlights. Gold Road booty handsomely deadlights Privateer brig bilged on her anchor.  " + "" +
                "Main sheet mizzen draft hornswaggle knave gally Pirate Round. Haul wind prow hogshead jolly boat case shot parley pinnace." +
                " Booty tack scuppers maroon square-rigged salmagundi Sail ho. Knave Yellow Jack weigh anchor coxswain furl marooned execution " +
                "dock. American Main shrouds fire in the hole scourge of the seven seas Jolly Roger draught heave to. ",
                PreviewText = "Barque topsail overhaul rum keelhaul swab hempen halter. Crack Jennys tea cup square-rigged flogging hornswaggle swab " +
                "tender Admiral of the Black. Sheet ballast ho killick bucko prow loot. Cat o'nine tails piracy booty rutters Pirate Round line yardarm. " +
                "Ballast aft galleon blow the man down hail-shot swab Barbary Coast. Me no prey, no pay port Pieces of Eight mizzen gunwalls barkadeer. " +
                "Sloop Jolly Roger brig doubloon bilge tackle blow the man down. Reef sails nipper crow's nest cackle fruit furl Sink me Jolly Roger. Crack" +
                " Jennys tea cup rutters cutlass hearties squiffy weigh anchor run a rig. Mizzen topmast piracy Davy Jones' Locker gangplank tender rum.",
                Tags = new List<string>(){"#firsttimecleric", "#whatisinspiration", "#magic"}
            }
        };

        private static List<BlogEntry> _queue = new List<BlogEntry>()
        {
            new BlogEntry()
            {
                BlogId = 4,
                Author = "MockSeed",
                DateCreated = DateTime.Today,
                Title = "Fourth Blog Post, First Queue",
                Category = _categories.FirstOrDefault(x=>x.Id == 2),
                FullText = "Barque topsail overhaul rum keelhaul swab hempen halter. Crack Jennys tea cup square-rigged flogging hornswaggle swab " +
                "tender Admiral of the Black. Sheet ballast ho killick bucko prow loot. Cat o'nine tails piracy booty rutters Pirate Round line yardarm. " +
                "Ballast aft galleon blow the man down hail-shot swab Barbary Coast. Me no prey, no pay port Pieces of Eight mizzen gunwalls barkadeer. " +
                "Sloop Jolly Roger brig doubloon bilge tackle blow the man down. Reef sails nipper crow's nest cackle fruit furl Sink me Jolly Roger. Crack" +
                " Jennys tea cup rutters cutlass hearties squiffy weigh anchor run a rig. Mizzen topmast piracy Davy Jones' Locker gangplank tender rum." +
                "Plate Fleet poop deck flogging transom haul wind skysail marooned. Carouser mizzen cog skysail fire ship crack Jennys tea cup topsail. Fire" +
                " in the hole Shiver me timbers yawl come about no prey, no pay tack hulk. Bilge rat jib code of conduct barque red ensign bounty chandler. " +
                "Yawl mizzenmast broadside dance the hempen jig haul wind clap of thunder come about. Hail-shot me pirate spyglass dance the hempen jig Yellow" +
                " Jack transom. Spike smartly crimp rope's end gibbet Letter of Marque American Main. Plunder bilge rat hornswaggle reef sails lugsail boatswain" +
                " wherry. Smartly capstan gibbet strike colors man-of-war log bring a spring upon her cable. Driver bounty man-of-war mutiny cackle fruit" +
                " run a shot across the bow crimp. Shrouds black spot fore crack Jennys tea cup belaying pin spyglass long boat. Gibbet ho piracy bucko skysail" +
                " parley knave. Avast hardtack landlubber or just lubber lugsail blow the man down spirits mizzen. Gun Nelsons folly loot swing the lead" +
                " black jack coffer deadlights. Gold Road booty handsomely deadlights Privateer brig bilged on her anchor.  " + "" +
                "Main sheet mizzen draft hornswaggle knave gally Pirate Round. Haul wind prow hogshead jolly boat case shot parley pinnace." +
                " Booty tack scuppers maroon square-rigged salmagundi Sail ho. Knave Yellow Jack weigh anchor coxswain furl marooned execution " +
                "dock. American Main shrouds fire in the hole scourge of the seven seas Jolly Roger draught heave to. ",
                PreviewText = "Barque topsail overhaul rum keelhaul swab hempen halter. Crack Jennys tea cup square-rigged flogging hornswaggle swab " +
                "tender Admiral of the Black. Sheet ballast ho killick bucko prow loot. Cat o'nine tails piracy booty rutters Pirate Round line yardarm. " +
                "Ballast aft galleon blow the man down hail-shot swab Barbary Coast. Me no prey, no pay port Pieces of Eight mizzen gunwalls barkadeer. " +
                "Sloop Jolly Roger brig doubloon bilge tackle blow the man down. Reef sails nipper crow's nest cackle fruit furl Sink me Jolly Roger. Crack" +
                " Jennys tea cup rutters cutlass hearties squiffy weigh anchor run a rig. Mizzen topmast piracy Davy Jones' Locker gangplank tender rum.",
                Tags = new List<string>(){"#notnewauthoranymore", "#whatisinspiration", "#magic"}
            }
        };
        public void Add(BlogEntry newBlog)
        {
            _queue.Remove(_queue.FirstOrDefault(x => x.BlogId == newBlog.BlogId));
            _all.Add(newBlog);
        }

        public void Delete(int blogId)
        {
            _all.Remove(_all.FirstOrDefault(x => x.BlogId == blogId));
        }

        public void Edit(BlogEntry editedBlog)
        {
            _all.Remove(_all.FirstOrDefault(x => x.BlogId == editedBlog.BlogId));
            _all.Add(editedBlog);
        }

        public BlogEntry Get(int blogId)
        {
            return _all.FirstOrDefault(x => x.BlogId == blogId);
        }

        public List<BlogEntry> GetAll()
        {
            return _all;
        }

        public List<string> GetTags(int blogId)
        {
            return _all.FirstOrDefault(x => x.BlogId == blogId).Tags;
        }
        public List<BlogEntry> GetByCategory(int categoryId)
        {
            List<BlogEntry> result = _all.Where(x => x.Category.Id == categoryId).ToList();
            return result;
        }
        public List<Category> GetCategories()
        {
            return _categories;
        }

        public List<BlogEntry> GetPostsByTag(string tags)
        {
            if (tags == null || tags == "")
            {
                return _all;
            }
            List<BlogEntry> result = new List<BlogEntry>();
            string[] alltags = tags.ToLower().Split(' ');
            foreach (BlogEntry x in _all)
            {
                foreach (string y in x.Tags)
                {
                    if (y != " " && y != "")
                    {
                        foreach (string z in alltags)
                        {
                            if (y.ToLower().Contains(z))
                            {
                                if (!result.Contains(x))
                                {
                                    result.Add(x);
                                }
                            }
                        }
                    }
                }
            }
            return result;
        }
        public List<BlogEntry> GetQueue()
        {
            return _queue;
        }
        public void AddToQueue(BlogEntry x)
        {
            _queue.Add(x);
        }
        public BlogEntry GetFromQueue(int blogId)
        {
            return _queue.FirstOrDefault(x => x.BlogId == blogId);
        }
    }
}