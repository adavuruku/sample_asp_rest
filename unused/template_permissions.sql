-- Template creation and permission Doctor
-- ## Module 1 AND Permissions

INSERT INTO public.template (id, name, status, create_date, update_date, created_by, updated_by, deleted)
values ('cmbupqkv1003p356q6puvxvap', 'Doctor', 1, now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', false);

INSERT INTO public.template_permission (
    id, 
    module_id, 

    action_permission_id, 
    action_group_id, 
    
    template_id, create_date, update_date, created_by, updated_by, deleted)
values ('cmbv8vr1u0049356q5ginix8l','cmbtznqc2000h356q41sv4v6h','cmbu0vofm000n356qxqz02aou','cmbu1cshy001d356q9kwa4num','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),
     
     ('cmbv8vxfe004b356q6jgbboy4','cmbtznqc2000h356q41sv4v6h','cmbu1q5j6001h356q85oqey3v','cmbu1cshy001d356q9kwa4num','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),
     
     ('cmbv8w2u9004d356qdgporad0','cmbtznqc2000h356q41sv4v6h','cmbu1qt0f001j356qiymzz6if','cmbu1cshy001d356q9kwa4num', 'cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),
     
     ('cmbv8we30004f356q8s7f8s6n','cmbtznqc2000h356q41sv4v6h','cmbu1saag001l356qblz490f6','cmbu1cshy001d356q9kwa4num','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),
     
    --  action group 2
     ('cmbv8wmta004h356q8nch7m81','cmbtznqc2000h356q41sv4v6h','cmbu0vofm000n356qxqz02aou','cmbu0vx3t000p356qo1nbhofd','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),

       ('cmbv8wu7r004j356qfr0atrnj','cmbtznqc2000h356q41sv4v6h','cmbu1q5j6001h356q85oqey3v','cmbu0vx3t000p356qo1nbhofd','cmbupqkv1003p356q6puvxvap',
      now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false);


-- Template creation and permission Doctor
-- ## Module 2 AND Permissions

INSERT INTO public.template_permission (
    id, 
    module_id, 

    action_permission_id, 
    action_group_id, 
    
    template_id, create_date, update_date, created_by, updated_by, deleted)
values ('cmbv8x44o004l356qu5kzt8x1','cmbu1yusk001n356q4pe8fhg9','cmbu25thz001t356q1safytp8','cmbu22k58001r356q1b4z2dp4','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),
     
     ('cmbv8xbhn004n356ql8b82kih','cmbu1yusk001n356q4pe8fhg9','cmbu2631j001v356qioppm1k2','cmbu22k58001r356q1b4z2dp4','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),
     
     ('cmbv8xk6v004p356qeuf1svo2','cmbu1yusk001n356q4pe8fhg9','cmbu26ork001x356qqvxor3hh','cmbu22k58001r356q1b4z2dp4', 'cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),
     
     ('cmbv8xt1v004r356q9dnvxzea','cmbu1yusk001n356q4pe8fhg9','cmbu26w6h001z356qy8wdgx1o','cmbu22k58001r356q1b4z2dp4','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),

     ('cmbv8y2fo004t356q729d199y','cmbu1yusk001n356q4pe8fhg9','cmbu277b60021356qjn7u2tyo','cmbu22k58001r356q1b4z2dp4','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),

      ('cmbv8y8zc004v356qliyldme5','cmbu1yusk001n356q4pe8fhg9','cmbu3687j003b356qiu2s38vy','cmbu22k58001r356q1b4z2dp4','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false);


-- Template creation and permission Doctor
-- ## Module 3

    INSERT INTO public.template_permission (
    id, 
    module_id, 

    action_permission_id, 
    action_group_id, 
    
    template_id, 
    create_date, update_date, created_by, updated_by, deleted)
values ('cmbv8yiw5004x356q4zsky4a5','cmbu29dpz0025356qjhpvrng3','cmbu2bfbi0029356qhh3e1ecu','cmbu2aeyk0027356qlqyik4aq','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),
     
     ('cmbv8ysx9004z356qmfid03ea','cmbu29dpz0025356qjhpvrng3','cmbu2bixq002b356qy4zfepvm','cmbu2aeyk0027356qlqyik4aq','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),
     
     ('cmbv8z2e60051356qll7gn8yd','cmbu29dpz0025356qjhpvrng3','cmbu2bn7n002d356qkrhnaa2t','cmbu2aeyk0027356qlqyik4aq', 'cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),
     
     ('cmbv8z8i00053356q5rmoo3m3','cmbu29dpz0025356qjhpvrng3','cmbu2brx6002f356qizvz3y7i','cmbu2aeyk0027356qlqyik4aq','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),

    --  group 2

     ('cmbv8zhac0055356qo81cihpr','cmbu29dpz0025356qjhpvrng3','cmbu2gz1c002j356q8yx0x64a','cmbu2etd5002h356qwcfujko8','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),

      ('cmbv8zr3s0057356qlol3770y','cmbu29dpz0025356qjhpvrng3','cmbu2hd56002l356qwd31zouu','cmbu2etd5002h356qwcfujko8','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),
     
     ('cmbv8zzp20059356qdzcv6s1y','cmbu29dpz0025356qjhpvrng3','cmbu38lr0003d356qm9l543cy','cmbu2etd5002h356qwcfujko8','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false);


    -- ##  Module 4

    INSERT INTO public.template_permission (
    id, 
    module_id, 

    action_permission_id, 
    action_group_id, 
    
    template_id, 
    create_date, update_date, created_by, updated_by, deleted)
values ('cmbv90bwb005b356qu5ip6tro','cmbu2jsue002p356qdj3zp06x','cmbu2kha3002t356q61evitze','cmbu2k75s002r356qs4tgr1fi','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),
     
     ('cmbv90hku005d356qrduevrrj','cmbu2jsue002p356qdj3zp06x','cmbu2kqiq002v356qk0s9qae3','cmbu2k75s002r356qs4tgr1fi','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),
     
     ('cmbv90ood005f356q9u0db613','cmbu2jsue002p356qdj3zp06x','cmbu3fgll003n356qlgy6s78y','cmbu2k75s002r356qs4tgr1fi', 'cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),
     
     ('cmbv90w1r005h356qfxh9pt8g','cmbu2jsue002p356qdj3zp06x','cmbu3f92e003l356q0ajgysts','cmbu2k75s002r356qs4tgr1fi','cmbupqkv1003p356q6puvxvap', now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),

     ('cmbv912sp005j356qdmgs127d','cmbu2jsue002p356qdj3zp06x','cmbu3f1fg003j356q85tev6n2','cmbu2k75s002r356qs4tgr1fi','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),

      ('cmbv918hp005l356qzk9vmtfq','cmbu2jsue002p356qdj3zp06x','cmbu2mxcb0033356qdualmoo3','cmbu2k75s002r356qs4tgr1fi','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),
     
     ('cmbv91g3e005n356q9pij1mq5','cmbu2jsue002p356qdj3zp06x','cmbu3ciqi003h356qmjfa5319','cmbu2k75s002r356qs4tgr1fi','cmbupqkv1003p356q6puvxvap',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false);


-- Template creation and permission Doctor
-- Desk Officer
-- Template creation and permission Doctor
-- Desk Officer

INSERT INTO public.template (id, name, status, create_date, update_date, created_by, updated_by, deleted)
values ('cmbv9uvk6005r356qaws44waf', 'Desk officer', 1, now(), now(), 'cmbu1zobp001p356qh2p2xtaw', 'cmbu1zobp001p356qh2p2xtaw', false);


INSERT INTO public.template_permission (
    id, 
    module_id, 

    action_permission_id, 
    action_group_id, 
    
    template_id, 
    create_date, update_date, created_by, updated_by, deleted)
values ('cmbvajn7y005z356qtt7kj13i','cmbu29dpz0025356qjhpvrng3','cmbu2gz1c002j356q8yx0x64a','cmbu2etd5002h356qwcfujko8','cmbv9uvk6005r356qaws44waf',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),

      ('cmbvajslv0061356qj1qef1in','cmbu29dpz0025356qjhpvrng3','cmbu2hd56002l356qwd31zouu','cmbu2etd5002h356qwcfujko8','cmbv9uvk6005r356qaws44waf',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),
     
     ('cmbvajyj10063356qzxbdcic9','cmbu29dpz0025356qjhpvrng3','cmbu38lr0003d356qm9l543cy','cmbu2etd5002h356qwcfujko8','cmbv9uvk6005r356qaws44waf',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),
     ('cmbvanxij0065356q84uek40n','cmbu2jsue002p356qdj3zp06x','cmbu3f1fg003j356q85tev6n2','cmbu2k75s002r356qs4tgr1fi','cmbv9uvk6005r356qaws44waf',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false),

      ('cmbvao1a10067356qgbwjrdr1','cmbu2jsue002p356qdj3zp06x','cmbu2mxcb0033356qdualmoo3','cmbu2k75s002r356qs4tgr1fi','cmbv9uvk6005r356qaws44waf',
     now(), now(), 'cmbu1zobp001p356qh2p2xtaw','cmbu1zobp001p356qh2p2xtaw', false);

