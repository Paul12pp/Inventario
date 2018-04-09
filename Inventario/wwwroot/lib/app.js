const express = require('express');
const bodyParser = require('body-parser');
const exphs = require('express-handlebars');
const path = require('path');
const nodemailer = require('nodemailer');
const app = express();

var smtpTransport = nodemailer.createTransport({
    service: 'gmail',
    port: 465,
    secure: true,
    auth: {
        user: 'paulreys12@gmail.com',
        pass: 'Fuckencio12pp'
    }
});

//view engine setup
app.engine('handlebars', exphs());
app.set('view engine', 'handlebars');

//body parse Middleware


//Public folder


app.get('/', (req, res) => {
    res.sendfile('/Factura/Create')
    res.send('Hello');
});

app.get('/send', function (req, res) {
    var mailOptions = {
        to: req.query.to,
        subject: req.query.subject,
        text: req.query.text
    }
    console.log(mailOptions);
    smtpTransport.sendMail(mailOptions, function (error, response) {
        if (error) {
            console.log(error);
            res.end("error");
        } else {
            console.log("Message sent: " + response.message);
            res.end("sent");
        }
    });
});

app.listen(3000, () => console.log('Server started...'))

