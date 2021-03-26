# -*- coding: utf-8 -*-
from odoo import models, fields, api
from datetime import datetime

class Visit(models.Model):
    _name = 'custom_crm.visit'
    _description = 'Visit'

    name = fields.Char(string='Descripció')
    customer = fields.Many2one(comodel_name='res.partner', string='Client')
    date = fields.Integer(compute='_compute_difference')
    type = fields.Selection([('P','Presencial'),('W','Whatsapp'),('T','Telefon')], string='Tipus',required=True)
    done = fields.Boolean(string='Fet',readonly=True)

def _compute_difference(self):
    date = 20
    #for rec in self:
        #rec.days_difference = (datetime.date.time.today()- rec.created_date).days