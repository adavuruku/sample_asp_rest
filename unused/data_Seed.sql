-- Module 1

INSERT INTO public.modules (id, name, status, create_date, update_date, created_by, updated_by, deleted)
values ('cmbtznqc2000h356q41sv4v6h', 'Patient', 1, now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true);

INSERT INTO public.action_group (id, name, module_id, create_date, update_date, created_by, updated_by, deleted)
values ('cmbu1cshy001d356q9kwa4num', 'Patience Management', 'cmbtznqc2000h356q41sv4v6h', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true);

INSERT INTO public.action_permission  (id, name, action_group_id, create_date, update_date, created_by, updated_by, deleted)
values ('cmbu0vofm000n356qxqz02aou', 'Create', 'cmbu1cshy001d356q9kwa4num', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),

('cmbu1q5j6001h356q85oqey3v', 'Update', 'cmbu1cshy001d356q9kwa4num', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),
('cmbu1qt0f001j356qiymzz6if', 'Delete', 'cmbu1cshy001d356q9kwa4num', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),
('cmbu1saag001l356qblz490f6', 'Report', 'cmbu1cshy001d356q9kwa4num', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true);

INSERT INTO public.action_group (id, name, module_id, create_date, update_date, created_by, updated_by, deleted)
values ('cmbu0vx3t000p356qo1nbhofd', 'Out Patient Management', 'cmbu1zobp001p356qh2p2xtaw', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true);

INSERT INTO public.action_permission  (id, name, action_group_id, create_date, update_date, created_by, updated_by, deleted)
values ('cmbu0vofm000n356qxqz02aou', 'Create', 'cmbu0vx3t000p356qo1nbhofd', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),

('cmbu1q5j6001h356q85oqey3v', 'Update', 'cmbu0vx3t000p356qo1nbhofd', now(), now());



-- Module 2

INSERT INTO public.modules (id, name, status, create_date, update_date, created_by, updated_by, deleted)
values ('cmbu1yusk001n356q4pe8fhg9', 'EClinic Management', 1, now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true);

INSERT INTO public.action_group (id, name, module_id, create_date, update_date, created_by, updated_by, deleted)
values ('cmbu22k58001r356q1b4z2dp4', 'User Management', 'cmbu1yusk001n356q4pe8fhg9', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true);

INSERT INTO public.action_permission  (id, name, action_group_id, create_date, update_date, created_by, updated_by, deleted)
values ('cmbu25thz001t356q1safytp8', 'Create', 'cmbu22k58001r356q1b4z2dp4', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),

('cmbu2631j001v356qioppm1k2', 'Update', 'cmbu22k58001r356q1b4z2dp4', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),

('cmbu26ork001x356qqvxor3hh', 'Delete', 'cmbu22k58001r356q1b4z2dp4', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),

('cmbu26w6h001z356qy8wdgx1o', 'Report', 'cmbu22k58001r356q1b4z2dp4', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),

('cmbu277b60021356qjn7u2tyo', 'Role Management', 'cmbu22k58001r356q1b4z2dp4', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),

('cmbu3687j003b356qiu2s38vy', 'Template Management', 'cmbu22k58001r356q1b4z2dp4', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true);


-- Module 3

INSERT INTO public.modules (id, name, status, create_date, update_date, created_by, updated_by, deleted)
values ('cmbu29dpz0025356qjhpvrng3', 'Laboratory Management', 1, now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true);

INSERT INTO public.action_group (id, name, module_id, create_date, update_date, created_by, updated_by, deleted)
values ('cmbu2aeyk0027356qlqyik4aq', 'Management', 'cmbu29dpz0025356qjhpvrng3', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true);

INSERT INTO public.action_permission  (id, name, action_group_id, create_date, update_date, created_by, updated_by, deleted)
values ('cmbu2bfbi0029356qhh3e1ecu', 'Create', 'cmbu2aeyk0027356qlqyik4aq', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),

('cmbu2bixq002b356qy4zfepvm', 'Update', 'cmbu2aeyk0027356qlqyik4aq', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),

('cmbu2bn7n002d356qkrhnaa2t', 'Delete', 'cmbu2aeyk0027356qlqyik4aq', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),

('cmbu2brx6002f356qizvz3y7i', 'Report', 'cmbu2aeyk0027356qlqyik4aq', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true);

INSERT INTO public.action_group (id, name, module_id, create_date, update_date, created_by, updated_by, deleted)
values ('cmbu2etd5002h356qwcfujko8', 'Entry', 'cmbu29dpz0025356qjhpvrng3', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true);

INSERT INTO public.action_permission  (id, name, action_group_id, create_date, update_date, created_by, updated_by, deleted)
values ('cmbu2gz1c002j356q8yx0x64a', 'Create', 'cmbu2etd5002h356qwcfujko8', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),

('cmbu2hd56002l356qwd31zouu', 'Open', 'cmbu2etd5002h356qwcfujko8', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),

('cmbu38lr0003d356qm9l543cy', 'Print', 'cmbu2etd5002h356qwcfujko8', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true);



-- Module 4

INSERT INTO public.modules (id, name, status, create_date, update_date, created_by, updated_by, deleted)
values ('cmbu2jsue002p356qdj3zp06x', 'Pharmacy', 1, now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true);

INSERT INTO public.action_group (id, name, module_id, create_date, update_date, created_by, updated_by, deleted)
values ('cmbu2k75s002r356qs4tgr1fi', 'Management', 'cmbu2jsue002p356qdj3zp06x', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true);

INSERT INTO public.action_permission  (id, name, action_group_id, create_date, update_date, created_by, updated_by, deleted)
values ('cmbu2kha3002t356q61evitze', 'Create', 'cmbu2k75s002r356qs4tgr1fi', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),

('cmbu2kqiq002v356qk0s9qae3', 'Update', 'cmbu2k75s002r356qs4tgr1fi', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),

('cmbu3fgll003n356qlgy6s78y', 'Delete', 'cmbu2k75s002r356qs4tgr1fi', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),

('cmbu3f92e003l356q0ajgysts', 'Report', 'cmbu2k75s002r356qs4tgr1fi', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true)

('cmbu3f1fg003j356q85tev6n2', 'Entry', 'cmbu2k75s002r356qs4tgr1fi', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),

('cmbu2mxcb0033356qdualmoo3', 'Open', 'cmbu2k75s002r356qs4tgr1fi', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true),

('cmbu3ciqi003h356qmjfa5319', 'Print', 'cmbu2k75s002r356qs4tgr1fi', now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true);



-- Template creation and permission Doctor

INSERT INTO public.template (id, name, status, create_date, update_date, created_by, updated_by, deleted)
values ('cmbupqkv1003p356q6puvxvap', 'Doctor', 1, now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true);

INSERT INTO public.template_permission (id, module_id, action_group_id, action_permission_id, template_id, status, create_date, update_date, created_by, updated_by, deleted)
values ('cmbupvpcc003r356qgoh5mo2g', 'Doctor', 1, now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', true);