const emner = require('express').Router();
var emne = require("../../Models/Emne");
const bodyParser = require('body-parser').json();

module.exports = emner.delete('/', (req, res) => {

    var emneToDelete = new emne(req.body);

    emne.deleteOne({ emne: emneToDelete.emne }, function (err) {
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