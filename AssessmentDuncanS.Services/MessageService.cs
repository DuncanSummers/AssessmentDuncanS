using AssessmentDuncanS.Data;
using AssessmentDuncanS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentDuncanS.Services
{
    // Create service layer for message requiring user IDs
    public class MessageService
    {
        private readonly Guid _userId;

        public MessageService(Guid userId)
        {
            _userId = userId;
        }

        // Use linq to create message using model
        public bool CreateMessage(MessageCreate model)
        {
            var entity =
                new Message()
                {
                    Sender = _userId,
                    Recipient = model.Recipient,
                    Content = model.Content,
                    SentUTC = DateTimeOffset.Now
                };
            // Add message to database
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Messages.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        // create service where you can see messages you sent
        public IEnumerable<MessageListItem> GetMessages()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Messages
                        .Where(e => e.Sender == _userId)
                        .Select(
                            e =>
                                new MessageListItem()
                                {
                                    MessageID = e.MessageID,
                                    Sender = e.Sender,
                                    SentUTC = e.SentUTC
                                }
                         );
                return query.ToArray();
            }
        }

        // MessageDetail method lists details using model created earlier using linq
        public MessageDetail GetMessageById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Messages.Single(e => e.MessageID == id && e.Sender == _userId);

                return new MessageDetail { MessageID = entity.MessageID, Content = entity.Content, SentUTC = entity.SentUTC };
            }
        }

        public bool UpdateNote(NoteEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteID == model.NoteID && e.OwnerID == _userId);

                entity.Title = model.Title;
                entity.Content = model.Content;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;
                entity.IsStarred = model.IsStarred;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteNote(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Notes
                        .Single(e => e.NoteID == noteId && e.OwnerID == _userId);

                ctx.Notes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
