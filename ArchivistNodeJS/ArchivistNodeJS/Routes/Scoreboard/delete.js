const scoreboards = require('express').Router();
var scoreboard = require("../../Models/Scoreboard");
const bodyParser = require('body-parser').json();

module.exports = scoreboards.delete('/', (req, res) => {

    var scoreboardToDelete = new scoreboard(req.body);

    scoreboard.deleteOne({ spillernavn: scoreboardToDelete.spillernavn }, function (err) {
        if (!err) {
            res.status(204).json({ 'Success': 'Deleted document' })
        } else {
            res.status(500).json({ 'Error': 'Contact an admin' })
        }
    })

});


//module.exports = (req, res) => {

//    //try catch
//    if (req.params.emne) {
//        // the object is defined
//        emne.deleteOne({ emne: req.params.emne }, function (err) {
//            if (!err) {
//                res.status(204).json({ 'Success': 'Deleted document' })
//            } else {
//                res.status(500).json({ 'Error': 'Contact an admin' })
//            }
//        })

//    } else {
//        const message = 'no valid params';
//        res.status(404).json({ message });
//    }
//};