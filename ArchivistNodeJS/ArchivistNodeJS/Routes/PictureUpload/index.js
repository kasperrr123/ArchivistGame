const models = require('express').Router();

const topic = require('./emner');
const question = require('./spørgsmål');

models.use('/topic', topic);

models.use('/question', question);





module.exports = models;