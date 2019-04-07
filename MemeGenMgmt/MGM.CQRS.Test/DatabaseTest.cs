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
        private User _user;
        private Meme _meme;
        private Memetag _memesTag;
        private Tag _tag;
        private Template _template;
        private Templatetag _templateTag;

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
            _user = new User
            {
                Mail = Guid.NewGuid() + "@bluewin.ch",
                Password = Guid.NewGuid().ToString(),
                Username = Guid.NewGuid().ToString()
            };
            _userStore.Insert(_user);

            using (var context = new MGMContext())
            {
                context.Attach(_user);
                var user = context.User.FirstOrDefault(x => x.Id == _user.Id);
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
            var user = new User
            {
                Mail = Guid.NewGuid() + "@bluewin.ch",
                Password = Guid.NewGuid().ToString(),
                Username = Guid.NewGuid().ToString()
            };

            Assert.IsTrue(_userStore.Update(user, _user.Id));

            using (var context = new MGMContext())
            {
                var updatedUser = context.User.FirstOrDefault(x => x.Id == _user.Id);

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
            _template = new Template
            {
                ImagePath = Guid.NewGuid() + ".png",
                Name = Guid.NewGuid().ToString()
            };

            using (var context = new MGMContext())
            {
                _templateStore.Insert(_template);
                context.Attach(_template);
                var template = context.Template.FirstOrDefault(x => x.Id == _template.Id);

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
            var template = new Template
            {
                ImagePath = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            };
            _templateStore.Update(template, _template.Id);

            using (var context = new MGMContext())
            {
                var updatedTemplate = context.Template.FirstOrDefault(x => x.Id == _template.Id);

                Assert.IsNotNull(updatedTemplate);
                Assert.AreEqual(template.ImagePath, updatedTemplate.ImagePath);
                Assert.AreEqual(template.Name, updatedTemplate.Name);

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
            _tag = new Tag
            {
                Description = Guid.NewGuid().ToString()
            };

            using (var context = new MGMContext())
            {
                _tagStore.Insert(_tag);
                context.Attach(_tag);
                var tag = context.Tag.FirstOrDefault(x => x.Id == _tag.Id);

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
            var tag = new Tag
            {
                Description = Guid.NewGuid().ToString()
            };

            using (var context = new MGMContext())
            {
                _tagStore.Update(tag, _tag.Id);
                var updatedTag = context.Tag.FirstOrDefault(x => x.Id == _tag.Id);

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
            _meme = new Meme
            {
                Bottom = Guid.NewGuid().ToString(),
                Created = DateTime.Now,
                FontSize = _random.Next(10, 20),
                ImagePath = Guid.NewGuid().ToString() + ".png",
                Name = Guid.NewGuid().ToString(),
                Top = Guid.NewGuid().ToString(),
                Updated = DateTime.Now,
                Watermark = Guid.NewGuid().ToString(),
                UserId = 1
            };

            using (var context = new MGMContext())
            {
                _memeStore.Insert(_meme);
                context.Attach(_meme);
                var meme = context.Meme.FirstOrDefault(x => x.Id == _meme.Id);

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
            _meme.Bottom = Guid.NewGuid().ToString();
            _meme.Created = DateTime.Now;
            _meme.FontSize = _random.Next(10, 20);
            _meme.ImagePath = Guid.NewGuid().ToString();
            _meme.Name = Guid.NewGuid().ToString();
            _meme.Top = Guid.NewGuid().ToString();
            _meme.Updated = DateTime.Now;
            _meme.Watermark = Guid.NewGuid().ToString();

            using (var context = new MGMContext())
            {
                _memeStore.Update(_meme, _meme.Id);
                var updatedMeme = context.Meme.FirstOrDefault(x => x.Id == _meme.Id);
                
                Assert.IsNotNull(updatedMeme);

                Assert.AreEqual(updatedMeme.Bottom, _meme.Bottom);
                Assert.AreEqual(updatedMeme.FontSize, _meme.FontSize);
                Assert.AreEqual(updatedMeme.FontSize, _meme.FontSize);
                Assert.AreEqual(updatedMeme.ImagePath, _meme.ImagePath);
                Assert.AreEqual(updatedMeme.Name, _meme.Name);
                Assert.AreEqual(updatedMeme.Top, _meme.Top);
                Assert.AreEqual(updatedMeme.Watermark, _meme.Watermark);
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
            _meme = new Meme
            {
                Bottom = Guid.NewGuid().ToString(),
                Created = DateTime.Now,
                FontSize = _random.Next(10, 20),
                ImagePath = Guid.NewGuid().ToString() + ".png",
                Name = Guid.NewGuid().ToString(),
                Top = Guid.NewGuid().ToString(),
                Updated = DateTime.Now,
                Watermark = Guid.NewGuid().ToString(),
                UserId = 1
            };

            _tag = new Tag
            {
                Description = Guid.NewGuid().ToString()
            };

            _memeStore.Insert(_meme);
            _tagStore.Insert(_tag);

            using (var context = new MGMContext())
            {
                context.Attach(_tag);
                context.Attach(_meme);
                _memesTag = new Memetag
                {
                    TagId = _tag.Id,
                    MemeId = _meme.Id
                };
                _memeTagStore.Insert(_memesTag);
                context.Attach(_memesTag);

                var insertedMemeTag =
                    context.Memetag.FirstOrDefault(x => x.TagId == _memesTag.TagId && x.MemeId == _memesTag.MemeId);
                Assert.IsNotNull(insertedMemeTag);
            }
        }

        [Test, Order(18)]
        public void MemeTagSelect()
        {
            Assert.AreEqual(_memeTagStore.SelectById(_memesTag.TagId, _memesTag.MemeId).Count(), 1);
            Assert.Greater(_memeTagStore.Select().Count(), 0);
        }

        [Test, Order(19)]
        public void MemeTagUpdate()
        { }

        [Test, Order(20)]
        public void MemeTagDelete()
        {
            Assert.IsTrue(_memeTagStore.Delete(null, _memesTag.TagId, _memesTag.MemeId));
        }

        [Test, Order(21)]
        public void TemplateTagInsert()
        {
            _template = new Template
            {
                ImagePath = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString()
            };

            _tag = new Tag
            {
                Description = Guid.NewGuid().ToString()
            };

            using (var context = new MGMContext())
            {
                _templateStore.Insert(_template);
                _tagStore.Insert(_tag);

                context.Attach(_template);
                context.Attach(_tag);

                _templateTag = new Templatetag
                {
                    TagId = _tag.Id,
                    TemplateId = _template.Id
                };
                _templateTagStore.Insert(_templateTag);

                Assert.IsNotNull(context.Templatetag.FirstOrDefault(x => x.TagId == _templateTag.TagId && x.TemplateId == _templateTag.TemplateId));
            }
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
            Assert.IsTrue(_templateTagStore.Delete(null, _tag.Id, _template.Id));
        }
    }
}