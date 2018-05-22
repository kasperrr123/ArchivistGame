const models = require('express').Router();

const post = require('./post');

models.post('/', post);





module.exports = models;