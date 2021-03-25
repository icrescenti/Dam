# -*- coding: utf-8 -*-
from odoo import models, fields, api

class Visit(models.Model):
    _name = 'custom_crm.visit'
    _description = 'Visit'

    name = fields.Char(string='Descripció')
    customer = fields.Char(string='Client')
    date = fields.Datetime(string='Data')
    type = fields.Selection([('P','Presencial'),('W','Whatsapp'),('T','Telefon')], string='Tipus',required=True)
    done = fields.Boolean(string='Fet',readonly=True)