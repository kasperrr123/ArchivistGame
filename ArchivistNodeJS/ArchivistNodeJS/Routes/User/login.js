const users = require('express').Router();
const user = require('../../Models/User');
const bodyParser = require('body-parser').json();
const jwt = require('jsonwebtoken');

module.exports = users.post('/login', bodyParser, (req, res) => {
    //error messages 210 no username
    //error messages 211 wrong password
    //success messages 200
    
    var userToSave = new user(req.body);

    try {
        user.collection.findOne({ username: {$regex: new RegExp(userToSave.username, "ig") } }, 'password type username', function (err, person) {
            var message = 210;
            try {
                if (err) {
                    res.send(message);
                } else {
                    if (userToSave.password == person.password) {
                        var payload = {
                            username:person.username,
                            type:person.type
                        }
                        var message = 200;
                        var token = jwt.sign(payload,'secret',{expiresIn:60*3})
                        res.status(message).json({success:'access granted',token:token});
                    } else {
                        message = 211;
                        res.status(message).json("Wrong password");
                    }

                }
            } catch (e) {
                res.status(message).json("no user");
            }
           
        });
    } catch (e) {
        res.send(message)
    }
  
});