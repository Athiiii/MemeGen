using System;
using System.Linq;
using MGM.CQRS.Models;
using NUnit.Framework;
using MGM.CQRS.Store;

namespace MGM.CQRS.Test
{
    public class DatabaseTest
    {
        //Stores
        private MemeStore _memeStore;
        private MemeTagStore _memeTagStore;
        private TagStore _tagStore;
        private TemplateStore _templateStore;
        private TemplateTagStore _templateTagStore;
        private UserStore _userStore;

        //Models
        private UsersSet _user;
        private MemesSet _meme;
        private MemesTag _memesTag;
        private TagSet _tag;
        private TemplateSet _template;
        private TemplateTag _templateTag;

        //Functions
        private Random _random;

        [SetUp]
        public void Setup()
        {
            _memeStore = new MemeStore();
            _memeTagStore = new MemeTagStore();
            _tagStore = new TagStore();
            _templateStore = new TemplateStore();
            _templateTagStore = new TemplateTagStore();
            _userStore = new UserStore();

            _random = new Random();
        }

        [Test, Order(1)]
        public void UserInsert()
        {
            _user = new UsersSet
            {
                Mail = Guid.NewGuid() + "@bluewin.ch",
                Password = Guid.NewGuid().ToString(),
                Username = Guid.NewGuid().ToString()
            };
            _userStore.Insert(_user);

            using (var context = new MGMContext())
            {
                context.Attach(_user);
                var user = context.UsersSet.FirstOrDefault(x => x.Id == _user.Id);
                Assert.IsNotNull(user);
            }
        }

        [Test, Order(2)]
        public void UserSelect()
        {
            Assert.IsNotNull(_userStore.SelectById(_user.Id));
            Assert.Greater(_userStore.Select().Count(), 0);
        }

        [Test, Order(3)]
        public void UserUpdate()
        {
            var user = new UsersSet
            {
                Mail = Guid.NewGuid() + "@bluewin.ch",
                Password = Guid.NewGuid().ToString(),
                Username = Guid.NewGuid().ToString()
            };

            Assert.IsTrue(_userStore.Update(user, _user.Id));

            using (var context = new MGMContext())
            {
                context.Attach(user);
                var updatedUser = context.UsersSet.FirstOrDefault(x => x.Id == user.Id);

                Assert.IsNotNull(updatedUser);
                Assert.AreEqual(user.Mail, updatedUser.Mail);
                Assert.AreEqual(user.Password, updatedUser.Password);
                Assert.AreEqual(user.Username, updatedUser.Username);
            }
        }


        [Test, Order(4)]
        public void UserDelete()
        {
            Assert.IsTrue(_userStore.Delete(null, _user.Id));
        }

        [Test, Order(5)]
        public void TemplateInsert()
        {
            _template = new TemplateSet
            {
                ImagePath = Guid.NewGuid() + ".png",
                Name = Guid.NewGuid().ToString()
            };

            using (var context = new MGMContext())
            {
                context.Attach(_template);
                var template = context.TemplateSet.FirstOrDefault(x => x.Id == _template.Id);

                Assert.IsNotNull(template);
            }
        }

        [Test, Order(6)]
        public void TemplateSelect()
        {
            Assert.IsNotNull(_templateStore.SelectById(_template.Id));
            Assert.Greater(_templateStore.Select().Count(), 0);
        }

        [Test, Order(7)]
        public void TemplateUpdate()
        {
            var template = new TemplateSet
            {
                ImagePath = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            };
            _templateStore.Update(template, _template.Id);

            using (var context = new MGMContext())
            {
                var updatedTemplate = context.TemplateSet.FirstOrDefault(x => x.Id == _template.Id);
                Assert.IsNotNull(template);

                if (updatedTemplate != null)
                {
                    Assert.AreEqual(_template.ImagePath, updatedTemplate.ImagePath);
                    Assert.AreEqual(_template.Name, updatedTemplate.Name);
                }
            }
        }

        [Test, Order(8)]
        public void TemplateDelete()
        {
            Assert.IsTrue(_templateStore.Delete(null, _template.Id));
        }

        [Test, Order(9)]
        public void TagInsert()
        {
            _tag = new TagSet
            {
                Description =  Guid.NewGuid().ToString()
            };
            _tagStore.Insert(_tag);

            using (var context = new MGMContext())
            {
                context.Attach(_tag);
                var tag = context.TagSet.FirstOrDefault(x => x.Id == _tag.Id);

                Assert.IsNotNull(tag);
            }
        }

        [Test, Order(10)]
        public void TagSelect()
        {
            Assert.IsNotNull(_tagStore.SelectById(_tag.Id));
            Assert.Greater(_tagStore.Select().Count(), 0);
        }

        [Test, Order(11)]
        public void TagUpdate()
        {
            var tag = new TagSet
            {
                Description = Guid.NewGuid().ToString()
            };
            _tagStore.Update(tag, _tag.Id);

            using (var context = new MGMContext())
            {
                var updatedTag = context.TagSet.FirstOrDefault(x => x.Id == _tag.Id);

                Assert.IsNotNull(updatedTag);
                Assert.AreEqual(updatedTag.Description, tag.Description);
            }
        }

        [Test, Order(12)]
        public void TagDelete()
        {
            Assert.IsTrue(_tagStore.Delete(null, _tag.Id));
        }

        [Test, Order(13)]
        public void MemeInsert()
        {
            _meme = new MemesSet
            {
                Bottom = Guid.NewGuid().ToString(),
                Created = DateTime.Now,
                FontSize = _random.Next(10, 20),
                ImagePath = Guid.NewGuid().ToString() + ".png",
                Name = Guid.NewGuid().ToString(),
                Top = Guid.NewGuid().ToString(),
                Updated = DateTime.Now,
                Watermark = Guid.NewGuid().ToString(),
                UsersId = 1
            };
            _memeStore.Insert(_meme);

            using (var context = new MGMContext())
            {
                context.Attach(_meme);
                var meme = context.MemesSet.FirstOrDefault(x => x.Id == _meme.Id);

                Assert.IsNotNull(meme);
            }
        }

        [Test, Order(14)]
        public void MemeSelect()
        {
            Assert.IsNotNull(_memeStore.SelectById(_meme.Id));
            Assert.Greater(_memeStore.Select().Count(), 0);
        }

        [Test, Order(14)]
        public void MemeUpdate()
        {
            var meme = new MemesSet
            {
                Bottom = Guid.NewGuid().ToString(),
                Created = DateTime.Now,
                FontSize = _random.Next(10,20),
                ImagePath = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString(),
                Top = Guid.NewGuid().ToString(),
                Updated = DateTime.Now,
                Watermark = Guid.NewGuid().ToString()
            };

            _memeStore.Update(meme, _meme.Id);

            using (var context = new MGMContext())
            {
                var updatedMeme = context.MemesSet.FirstOrDefault(x => x.Id == _meme.Id);
                Assert.IsNotNull(updatedMeme);

                Assert.AreEqual(updatedMeme.Bottom, meme.Bottom);
                Assert.AreEqual(updatedMeme.Created, meme.Created);
                Assert.AreEqual(updatedMeme.FontSize, meme.FontSize);
                Assert.AreEqual(updatedMeme.FontSize, meme.FontSize);
                Assert.AreEqual(updatedMeme.ImagePath, meme.ImagePath);
                Assert.AreEqual(updatedMeme.Name, meme.Name);
                Assert.AreEqual(updatedMeme.Top, meme.Top);
                Assert.AreEqual(updatedMeme.Updated, meme.Updated);
                Assert.AreEqual(updatedMeme.Watermark, meme.Watermark);
            }
        }

        [Test, Order(16)]
        public void MemeDelete()
        {
            Assert.IsTrue(_memeStore.Delete(null, _meme.Id));
        }

        [Test, Order(17)]
        public void MemeTagInsert()
        {
        }

        [Test, Order(18)]
        public void MemeTagSelect()
        {
            Assert.AreEqual(_memeTagStore.SelectById(_memesTag.TagId, _memesTag.MemesId).Count(), 1);
            Assert.Greater(_memeTagStore.Select().Count(), 0);
        }

        [Test, Order(19)]
        public void MemeTagUpdate()
        {
        }

        [Test, Order(20)]
        public void MemeTagDelete()
        {
        }

        [Test, Order(21)]
        public void TemplateTagInsert()
        {
        }

        [Test, Order(22)]
        public void TemplateTagSelect()
        {
            Assert.AreEqual(_templateTagStore.SelectById(_templateTag.TagId, _templateTag.TemplateId).Count(), 1);
            Assert.Greater(_templateTagStore.Select().Count(), 0);
        }

        [Test, Order(23)]
        public void TemplateTagUpdate()
        {
        }

        [Test, Order(24)]
        public void TemplateTagDelete()
        {
        }
    }
}