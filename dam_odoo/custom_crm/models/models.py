# -*- coding: utf-8 -*-
from odoo import models, fields, api
from datetime import date

class Visit(models.Model):
    _name = 'custom_crm.visit'
    _description = 'Visit'

    name = fields.Char(string='Descripció')
    customer = fields.Many2one(comodel_name='res.partner', string='Client')
    date = fields.Integer(compute='_compute_difference')
    type = fields.Selection([('P','Presencial'),('W','Whatsapp'),('T','Telefon')], string='Tipus',required=True)
    done = fields.Boolean(string='Fet',readonly=True)

    def f_create(self):
        self.create(
            {
                'name': "ORM Test",
                'customer': 1,
                'date': datetime.datetime.now(),
                'type': "W",
                'done': False,
            }
        )

    def f_search_update(self):
        self.search([('type', '=', 'W')])
        .write({'type': 'P'})
    
    def f_delete(self):
        self.unlink()

    def _compute_difference(self):
        for record in self:
            if record.date != False:
                record.days_from_visit = (datetime.datetime.now() - record.date).days_from_visit
                
        date = 1