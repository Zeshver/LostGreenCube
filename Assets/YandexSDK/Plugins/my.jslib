mergeInto(LibraryManager.library, {
  
  RateGame: function () {
    ysdk.feedback.canReview()
        .then(({ value, reason }) => {
            if (value) {
                ysdk.feedback.requestReview()
                    .then(({ feedbackSent }) => {
                        console.log(feedbackSent);
                    })
            } else {
                console.log(reason)
            }
        })
  },
  
  SaveExtern: function(date){
	var dateString = UTF8ToString(date);
	var myobj = JSON.parse(dateString);
	player.setData(myobj);
  },
  
  LoadExtern: function(){
	player.getData().then(_date => {
		const myJSON = JSON.stringify(_date);
		myGameInstance.SendMessage('LevelSequenceController', 'LoadYandexDate', myJSON)
	});
  },
  
  SetToLeaderboard: function(value){
	ysdk.getLeaderboards()
       .then(lb => {
           lb.setLeaderboardScore('Level', value);
        }); 
  },
      
  ShowAdv: function(){
	ysdk.adv.showFullscreenAdv({
        callbacks: {
            onClose: function(wasShown) {
            // some action after close
            },
            onError: function(error) {
            // some action on error
            }
        }
    })
   },
  
  Help: function(){
	  ysdk.adv.showRewardedVideo({
    callbacks: {
        onOpen: () => {
          console.log('Video ad open.');
		  myGameInstance.SendMessage("SharedGameObjects", "PauseGame");
        },
        onRewarded: () => {
          console.log('Rewarded!');
		  myGameInstance.SendMessage("SharedGameObjects", "OpenHelpPanel");
        },
        onClose: () => {
          console.log('Video ad closed.');
		  myGameInstance.SendMessage("SharedGameObjects", "PlayGame");
        }, 
        onError: (e) => {
          console.log('Error while open video ad:', e);
        }
    }
})
  },  
});