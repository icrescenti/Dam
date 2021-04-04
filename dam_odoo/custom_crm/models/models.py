# -*- coding: utf-8 -*-
from odoo import models, fields, api
from datetime import datetime
import time

class Visit(models.Model):
    _name = 'custom_crm.visit'
    _description = 'Visit'

    name = fields.Char(string='Descripció')
    customer = fields.Many2one(comodel_name='res.partner', string='Client')
    date = fields.Integer(compute='_compute_difference')
    type = fields.Selection([('P','Presencial'),('W','Whatsapp'),('T','Telefon')], string='Tipus',required=True)
    done = fields.Boolean(string='Fet',readonly=True)

    def _compute_difference(self):
        d1=time.strftime("%Y-%m-%d")
        d2=self.created_date
        
        d1=datetime.strptime(str(d1),'%Y-%m-%d') 
        d2=datetime.strptime(str(d2),'%Y-%m-%d')
        d3=d1-d2
        self.date=str(d3.days)