mergeInto(LibraryManager.library, {
  Show : function() {
    ysdk.adv.showFullscreenAdv({
    callbacks: {
        onClose: function(wasShown) {

        },
        onError: function(error) {

        }
    }
  })
  },

  SetToLeaderBoard : function(value) {
    ysdk.getLeaderboards()
    .then(lb => {
    // Без extraData
      lb.setLeaderboardScore('Rating', value);
    });
  },

  SaveExtern : function(data) {
    var dataString = UTF8ToString(data);
    var myobj = JSON.parse(dataString);
    player.setData(myobj);
  },

  GetLang : function() {
    try {
      var lang = ysdk.environment.i18n.lang;
      var bufferSize = lengthBytesUTF8(lang) + 1;
      var buffer = _malloc(bufferSize);
      stringToUTF8(lang, buffer, bufferSize);
      return buffer;
    } catch(err) {
      
    }
  },

  GetDataAgain : function() {
    try {
      player.getData().then(_data => {
        const myJSON = JSON.stringify(_data);
        myGameInstance.SendMessage('Progress', 'SetPlayerInfo', myJSON);
      });
    } catch (err) {

    }
  },
});