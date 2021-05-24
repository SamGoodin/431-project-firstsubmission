03/09/20 - Updated 16 pages for header and footer code restructuring - UserContent


Roles:
0 - Users
1 - Program Manager
2 - Admin
3 - Super Admin
-----------------------------------------------------------------------------------------
(CAREFUL! W/O A WHERE CLAUSE THIS WILL AFFECT THE ENTIRE COLUMN)
UPDATE Field
SET Active = 'Yes'
;
-----------------------------------------------------------------------------------------

User should be able to see create a program?  NO ONLY PROGRAM MANAGERS
Only after manager/admin login can they create a program? YES
May need to check for roles on page_load as well as session email exist. (example is in manageadministrators.aspx.cs)
Reminder: Program Manager page is emailed by Ernie only. Accessible by URL to anyone but not linked anywhere in site. 


TODO LIST:
- MAKE ALL SQL PARAMETERIZED ASAP
- Cost FK in Program table will need to be recreated
- SQL errors still output to page. Will need to eventually move to log folder. 
- Need to prevent empty additions to maintenance tables
- Need to add check of 'Role' to each page
- Stipend limited to 4 characters, either limit on input or change DB column.
- Some of the password fields are not protected. 
- last login dates need to be added to login page
- manageadministrators needs more width
- removed program residence eligibility autopostback. No place in DB for it?
- need to resolve university affilliations
- program service area other not working 
- I had to delete the FKs in the program table. Will need to recreate.
- program abbreviation not in DB
- Id like to move the super admin changing the admin passwords to something else. redirect to current change
  password with the admin being changed as a session var.
- use labels outside of textboxs on registration
- require distinct emails on registration
  

