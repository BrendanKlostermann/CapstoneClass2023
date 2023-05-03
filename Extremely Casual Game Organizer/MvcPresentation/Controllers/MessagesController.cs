using DataObjects;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPresentation.Controllers
{
    public class MessagesController : Controller
    {
        MessageManager _messageManager = new MessageManager();
        private MemberManager _memberManager = new MemberManager();
        List<Member> members = new List<Member>();
        List<Message> messages = new List<Message>();
        Member otherMember = new Member();
        private Member _member;

        // GET: Message

        [Authorize]
        public ActionResult Index(string email)
        {
            try
            {
                int member_id = GetUserID(User.Identity.Name);
                otherMember = GetUserData(email);

                if (member_id > 0 && otherMember != null)
                {
                    messages = _messageManager.GetMessages(member_id, otherMember.MemberID);
                    ViewBag.Me = member_id;
                    ViewBag.Him = otherMember.MemberID;
                    ViewBag.Email = otherMember.Email;
                    ViewBag.MemberName = otherMember.FirstName + " " + otherMember.FamilyName;
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An Error occured! " + ex.Message);
            }

            if (messages != null)
            {
                foreach (Message line in messages)
                {
                    if (line.ProfilePhoto != null)
                    {
                        string imreBase64Data = Convert.ToBase64String(line.ProfilePhoto);
                        string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
                        //Passing image data in viewbag to view
                        line.Photo = imgDataURL;
                    }
                }
            }
            return View(messages);
        }


        // GET: People I texted
        [Authorize]
        public ActionResult PeopleITexted()
        {
            try
            {
                int member_id = GetUserID(User.Identity.Name);
                if (member_id > 0)
                {
                    members = _messageManager.GetMembers(member_id);

                    ViewBag.Me = member_id;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ("An Error occured! " + ex.Message);
                return View("Error");
            }

            if (members != null)
            {
                foreach (Member line in members)
                {
                    if (line.ProfilePhoto != null)
                    {
                        string imreBase64Data = Convert.ToBase64String(line.ProfilePhoto);
                        string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
                        //Passing image data in viewbag to view
                        line.Photo = imgDataURL;
                    }
                }
            }

            return View(members);
        }

        // GET: Send Message
        [Authorize]
        [HttpPost]
        public ActionResult Create(string message, int user_id, int other_user_id, string email)
        {
            try
            {
                Message _message = new Message()
                {
                    UserIdSender = user_id,
                    UserIdReceiver = other_user_id,
                    Date = DateTime.Now,
                    Important = true,
                    MessageText = message
                };

                int result = _messageManager.AddMessage(_message);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An Error occured! " + ex.Message);
            }

            return RedirectToAction("Index", new
            {
                email = email
            });
        }

        [HttpGet]
        [Authorize]
        public ActionResult AllMembers()
        {
            members = _memberManager.GetMembers();

            if (members != null)
            {
                foreach (Member line in members)
                {
                    if (line.ProfilePhoto != null)
                    {
                        string imreBase64Data = Convert.ToBase64String(line.ProfilePhoto);
                        string imgDataURL = string.Format("data:image/png;base64,{0}", imreBase64Data);
                        //Passing image data in viewbag to view
                        line.Photo = imgDataURL;
                    }
                }
            }

            return View(members);
        }

        [HttpPost]
        [Authorize]
        public ActionResult AllMembers(string username)
        {
            if (username != null && username != "")
            {
                ViewBag.Message = "Search for: " + username;
                members = _memberManager.GetMemberByName(username);
            }
            return View(members);
        }


        // Get user info
        public Member GetUserData(string email)
        {
            try
            {
                _member = _memberManager.GetMemberByName(email).First();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            return _member;
        }


        // Get user info
        public Member GetUserInfo(string email)
        {
            try
            {
                _member = _memberManager.GetMemberByName(email).First();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            return _member;
        }


        public int GetUserID(string email)
        {
            try
            {
                _member = _memberManager.GetMemberByName(email).First();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }

            return _member.MemberID;
        }

    }
}