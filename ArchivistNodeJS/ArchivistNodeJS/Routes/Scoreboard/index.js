const models = require('express').Router();
const all = require('./all');
const post = require('./post');
const del = require('./delete');
const put = require('./put');

models.get('/', all);

models.post('/', post);

models.delete('/', del);

models.put('/:scoreboard', put);



module.exports = models;