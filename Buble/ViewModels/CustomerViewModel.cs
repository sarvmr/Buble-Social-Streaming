using Buble.Models;
using Buble.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Buble.ViewModels
{
    public class CustomerViewModel : ViewModelBase
    {
        public List<UserModel> customers { get; set; }
        UserRepository userRepository;

        public CustomerViewModel()
        {
            userRepository = new UserRepository();
            customers = userRepository.GetByAll();
            customers = customers.Where(u => u.Username != Thread.CurrentPrincipal.Identity.Name).ToList<UserModel>();

            //var video = repo.GetByVideoId(clickedVideoID);
            //if (video != null)
            //{
            //    VideoDetail.Title = video.title;
            //    VideoDetail.Likes = video.likes;
            //    VideoDetail.Dislikes = video.dislikes;
            //    VideoDetail.Channel = video.channel;
            //    VideoDetail.ThumbnailURL = video.Thumbnail;
            //}
        }

        public void update_followings_and_followers(string Uid)
        {
            userRepository.addFollowing(Thread.CurrentPrincipal.Identity.Name, Uid);
            userRepository.addFollower(Uid, Thread.CurrentPrincipal.Identity.Name);
        }
    }
}
