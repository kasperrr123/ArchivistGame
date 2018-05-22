const models = require('express').Router();
const login = require('./login');
const post = require('./post');


models.post('/', post);

models.post('/login', login);




module.exports = models;