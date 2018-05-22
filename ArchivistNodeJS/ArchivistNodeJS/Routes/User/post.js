const users = require('express').Router();
const user = require('../../Models/User');
const bodyParser = require('body-parser').json();

module.exports = users.post('/', bodyParser, (req, res) => {

    var userToSave = new user(req.body);
    userToSave.save(function (err) {
        if (err) {
            res.send(err);
        } else {
            res.status(201).json(userToSave);
        }
    });
});