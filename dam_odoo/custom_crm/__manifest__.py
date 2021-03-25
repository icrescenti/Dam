# -*- coding: utf-8 -*-
{
    'name': "custom_crm",

    'summary': """
        Modul personalitzat per la practica UF2-PR1
    """,

    'description': """
        Modul de proves de odoo per a Sistemes de gestió empresarials
    """,

    'author': "Ivan Crescenti",
    'website': "https://www.icrescenti.com",

    # Categories can be used to filter modules in modules listing
    # Check https://github.com/odoo/odoo/blob/12.0/odoo/addons/base/data/ir_module_category_data.xml
    # for the full list
    'category': 'Uncategorized',
    'version': '0.1',

    # any module necessary for this one to work correctly
    'depends': ['base'],

    # always loaded
    'data': [
        # 'security/ir.model.access.csv',
        'views/views.xml',
        'views/templates.xml',
    ],
    # only loaded in demonstration mode
    'demo': [
        'demo/demo.xml',
    ],
}