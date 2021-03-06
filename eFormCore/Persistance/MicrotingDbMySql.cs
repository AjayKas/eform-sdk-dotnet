namespace eFormSqlController
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Storage;
    using MySql.Data.MySqlClient;
    using System;

    public partial class MicrotingDbMySql : DbContext, MicrotingContextInterface
    {
        public MicrotingDbMySql() { }

        public MicrotingDbMySql(DbContextOptions options)
          : base(options)
        {
        }
        public virtual Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade ContextDatabase
        {
            get => base.Database;
        }
        public virtual DbSet<case_versions> case_versions { get; set; }
        public virtual DbSet<cases> cases { get; set; }
        public virtual DbSet<check_list_site_versions> check_list_site_versions { get; set; }
        public virtual DbSet<check_list_sites> check_list_sites { get; set; }
        public virtual DbSet<check_list_value_versions> check_list_value_versions { get; set; }
        public virtual DbSet<check_list_values> check_list_values { get; set; }
        public virtual DbSet<check_list_versions> check_list_versions { get; set; }
        public virtual DbSet<check_lists> check_lists { get; set; }
        public virtual DbSet<entity_group_versions> entity_group_versions { get; set; }
        public virtual DbSet<entity_groups> entity_groups { get; set; }
        public virtual DbSet<entity_item_versions> entity_item_versions { get; set; }
        public virtual DbSet<entity_items> entity_items { get; set; }
        public virtual DbSet<field_types> field_types { get; set; }
        public virtual DbSet<field_value_versions> field_value_versions { get; set; }
        public virtual DbSet<field_values> field_values { get; set; }
        public virtual DbSet<field_versions> field_versions { get; set; }
        public virtual DbSet<fields> fields { get; set; }
        public virtual DbSet<log_exceptions> log_exceptions { get; set; }
        public virtual DbSet<logs> logs { get; set; }
        public virtual DbSet<notifications> notifications { get; set; }
        public virtual DbSet<settings> settings { get; set; }
        public virtual DbSet<site_versions> site_versions { get; set; }
        public virtual DbSet<site_worker_versions> site_worker_versions { get; set; }
        public virtual DbSet<site_workers> site_workers { get; set; }
        public virtual DbSet<sites> sites { get; set; }
        public virtual DbSet<unit_versions> unit_versions { get; set; }
        public virtual DbSet<units> units { get; set; }
        public virtual DbSet<uploaded_data> uploaded_data { get; set; }
        public virtual DbSet<uploaded_data_versions> uploaded_data_versions { get; set; }
        public virtual DbSet<worker_versions> worker_versions { get; set; }
        public virtual DbSet<workers> workers { get; set; }
        public virtual DbSet<tags> tags { get; set; }
        public virtual DbSet<tag_versions> tag_versions { get; set; }
        public virtual DbSet<taggings> taggings { get; set; }
        public virtual DbSet<tagging_versions> tagging_versions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
          
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);


            modelBuilder.Entity("eFormSqlController.case_versions", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<int?>("case_id");

                b.Property<string>("case_uid")
                    .HasMaxLength(255);

                b.Property<int?>("check_list_id");

                b.Property<DateTime?>("created_at");

                b.Property<string>("custom");

                b.Property<DateTime?>("done_at");

                b.Property<int?>("done_by_user_id");

                b.Property<string>("field_value_1");

                b.Property<string>("field_value_10");

                b.Property<string>("field_value_2");

                b.Property<string>("field_value_3");

                b.Property<string>("field_value_4");

                b.Property<string>("field_value_5");

                b.Property<string>("field_value_6");

                b.Property<string>("field_value_7");

                b.Property<string>("field_value_8");

                b.Property<string>("field_value_9");

                b.Property<string>("microting_check_uid")
                    .HasMaxLength(255);

                b.Property<string>("microting_uid")
                    .HasMaxLength(255);

                b.Property<int?>("site_id");

                b.Property<int?>("status");

                b.Property<string>("type")
                    .HasMaxLength(255);

                b.Property<int?>("unit_id");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("case_versions");
            });

            modelBuilder.Entity("eFormSqlController.cases", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                      .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<string>("case_uid")
                    .HasMaxLength(255);

                b.Property<int?>("check_list_id");

                b.Property<DateTime?>("created_at");

                b.Property<string>("custom");

                b.Property<DateTime?>("done_at");

                b.Property<int?>("done_by_user_id");

                b.Property<string>("field_value_1");

                b.Property<string>("field_value_10");

                b.Property<string>("field_value_2");

                b.Property<string>("field_value_3");

                b.Property<string>("field_value_4");

                b.Property<string>("field_value_5");

                b.Property<string>("field_value_6");

                b.Property<string>("field_value_7");

                b.Property<string>("field_value_8");

                b.Property<string>("field_value_9");

                b.Property<string>("microting_check_uid")
                    .HasMaxLength(255);

                b.Property<string>("microting_uid")
                    .HasMaxLength(255);

                b.Property<int?>("site_id");

                b.Property<int?>("status");

                b.Property<string>("type")
                    .HasMaxLength(255);

                b.Property<int?>("unit_id");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.HasIndex("check_list_id");

                b.HasIndex("done_by_user_id");

                b.HasIndex("site_id");

                b.HasIndex("unit_id");

                b.ToTable("cases");
            });

            modelBuilder.Entity("eFormSqlController.check_list_site_versions", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                     .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<int?>("check_list_id");

                b.Property<int?>("check_list_site_id");

                b.Property<DateTime?>("created_at");

                b.Property<string>("last_check_id")
                    .HasMaxLength(255);

                b.Property<string>("microting_uid")
                    .HasMaxLength(255);

                b.Property<int?>("site_id");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("check_list_site_versions");
            });

            modelBuilder.Entity("eFormSqlController.check_list_sites", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                     .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<int?>("check_list_id");

                b.Property<DateTime?>("created_at");

                b.Property<string>("last_check_id")
                    .HasMaxLength(255);

                b.Property<string>("microting_uid")
                    .HasMaxLength(255);

                b.Property<int?>("site_id");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.HasIndex("check_list_id");

                b.HasIndex("site_id");

                b.ToTable("check_list_sites");
            });

            modelBuilder.Entity("eFormSqlController.check_list_value_versions", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                     .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<int?>("case_id");

                b.Property<int?>("check_list_duplicate_id");

                b.Property<int?>("check_list_id");

                b.Property<int?>("check_list_value_id");

                b.Property<DateTime?>("created_at");

                b.Property<string>("status")
                    .HasMaxLength(255);

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("user_id");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("check_list_value_versions");
            });

            modelBuilder.Entity("eFormSqlController.check_list_values", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<int?>("case_id");

                b.Property<int?>("check_list_duplicate_id");

                b.Property<int?>("check_list_id");

                b.Property<DateTime?>("created_at");

                b.Property<string>("status")
                    .HasMaxLength(255);

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("user_id");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("check_list_values");
            });

            modelBuilder.Entity("eFormSqlController.check_list_versions", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<short?>("approval_enabled");

                b.Property<string>("case_type")
                    .HasMaxLength(255);

                b.Property<int?>("check_list_id");

                b.Property<DateTime?>("created_at");

                b.Property<string>("custom");

                b.Property<string>("description");

                b.Property<int?>("display_index");

                b.Property<short?>("done_button_enabled");

                b.Property<short?>("download_entities");

                b.Property<short?>("extra_fields_enabled");

                b.Property<short?>("fast_navigation");

                b.Property<int?>("field_1");

                b.Property<int?>("field_10");

                b.Property<int?>("field_2");

                b.Property<int?>("field_3");

                b.Property<int?>("field_4");

                b.Property<int?>("field_5");

                b.Property<int?>("field_6");

                b.Property<int?>("field_7");

                b.Property<int?>("field_8");

                b.Property<int?>("field_9");

                b.Property<string>("folder_name")
                    .HasMaxLength(255);

                b.Property<string>("label");

                b.Property<short?>("manual_sync");

                b.Property<short?>("multi_approval");

                b.Property<int?>("parent_id");

                b.Property<short?>("quick_sync_enabled");

                b.Property<int?>("repeated");

                b.Property<short?>("review_enabled");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("check_list_versions");
            });

            modelBuilder.Entity("eFormSqlController.check_lists", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                     .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<short?>("approval_enabled");

                b.Property<string>("case_type")
                    .HasMaxLength(255);

                b.Property<DateTime?>("created_at");

                b.Property<string>("custom");

                b.Property<string>("description");

                b.Property<int?>("display_index");

                b.Property<short?>("done_button_enabled");

                b.Property<short?>("download_entities");

                b.Property<short?>("extra_fields_enabled");

                b.Property<short?>("fast_navigation");

                b.Property<int?>("field_1");

                b.Property<int?>("field_10");

                b.Property<int?>("field_2");

                b.Property<int?>("field_3");

                b.Property<int?>("field_4");

                b.Property<int?>("field_5");

                b.Property<int?>("field_6");

                b.Property<int?>("field_7");

                b.Property<int?>("field_8");

                b.Property<int?>("field_9");

                b.Property<string>("folder_name")
                    .HasMaxLength(255);

                b.Property<string>("label");

                b.Property<short?>("manual_sync");

                b.Property<short?>("multi_approval");

                b.Property<int?>("parent_id");

                b.Property<int?>("parentid");

                b.Property<short?>("quick_sync_enabled");

                b.Property<int?>("repeated");

                b.Property<short?>("review_enabled");

                //b.Property<int?>("tagsid");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.HasIndex("parentid");

                //b.HasIndex("tagsid");

                b.ToTable("check_lists");
            });

            modelBuilder.Entity("eFormSqlController.entity_group_versions", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                     .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<DateTime?>("created_at");

                b.Property<int>("entity_group_id");

                b.Property<string>("microting_uid");

                b.Property<string>("name");

                b.Property<string>("type")
                    .HasMaxLength(50);

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("entity_group_versions");
            });

            modelBuilder.Entity("eFormSqlController.entity_groups", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                   .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<DateTime?>("created_at");

                b.Property<string>("microting_uid");

                b.Property<string>("name");

                b.Property<string>("type")
                    .HasMaxLength(50);

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("entity_groups");
            });

            modelBuilder.Entity("eFormSqlController.entity_item_versions", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                     .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<DateTime?>("created_at");

                b.Property<string>("description");

                b.Property<int>("display_index");

                b.Property<int?>("entity_group_id");

                b.Property<string>("entity_item_uid")
                    .HasMaxLength(50);

                b.Property<int>("entity_items_id");

                b.Property<string>("microting_uid");

                b.Property<string>("name");

                b.Property<short?>("synced");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("entity_item_versions");
            });

            modelBuilder.Entity("eFormSqlController.entity_items", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<DateTime?>("created_at");

                b.Property<string>("description");

                b.Property<int>("display_index");

                b.Property<int>("entity_group_id");

                b.Property<string>("entity_item_uid")
                    .HasMaxLength(50);

                b.Property<string>("microting_uid");

                b.Property<string>("name");

                b.Property<short?>("synced");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("entity_items");
            });

            modelBuilder.Entity("eFormSqlController.field_types", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<string>("description")
                    .HasMaxLength(255);

                b.Property<string>("field_type")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("field_types");
            });

            modelBuilder.Entity("eFormSqlController.field_value_versions", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                     .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<string>("accuracy")
                    .HasMaxLength(255);

                b.Property<string>("altitude")
                    .HasMaxLength(255);

                b.Property<int?>("case_id");

                b.Property<int?>("check_list_duplicate_id");

                b.Property<int?>("check_list_id");

                b.Property<DateTime?>("created_at");

                b.Property<DateTime?>("date");

                b.Property<DateTime?>("done_at");

                b.Property<int?>("field_id");

                b.Property<int?>("field_value_id");

                b.Property<string>("heading")
                    .HasMaxLength(255);

                b.Property<string>("latitude")
                    .HasMaxLength(255);

                b.Property<string>("longitude")
                    .HasMaxLength(255);

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("uploaded_data_id");

                b.Property<int?>("user_id");

                b.Property<string>("value");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("field_value_versions");
            });

            modelBuilder.Entity("eFormSqlController.field_values", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                     .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<string>("accuracy")
                    .HasMaxLength(255);

                b.Property<string>("altitude")
                    .HasMaxLength(255);

                b.Property<int?>("case_id");

                b.Property<int?>("check_list_duplicate_id");

                b.Property<int?>("check_list_id");

                b.Property<DateTime?>("created_at");

                b.Property<DateTime?>("date");

                b.Property<DateTime?>("done_at");

                b.Property<int?>("field_id");

                b.Property<string>("heading")
                    .HasMaxLength(255);

                b.Property<string>("latitude")
                    .HasMaxLength(255);

                b.Property<string>("longitude")
                    .HasMaxLength(255);

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("uploaded_data_id");

                b.Property<int?>("user_id");

                b.Property<string>("value");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.HasIndex("check_list_id");

                b.HasIndex("field_id");

                b.HasIndex("uploaded_data_id");

                b.HasIndex("user_id");

                b.ToTable("field_values");
            });

            modelBuilder.Entity("eFormSqlController.field_versions", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                     .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<short?>("barcode_enabled");

                b.Property<string>("barcode_type")
                    .HasMaxLength(255);

                b.Property<int?>("check_list_id");

                b.Property<string>("color")
                    .HasMaxLength(255);

                b.Property<DateTime?>("created_at");

                b.Property<string>("custom");

                b.Property<int?>("decimal_count");

                b.Property<string>("default_value");

                b.Property<string>("description");

                b.Property<int?>("display_index");

                b.Property<short?>("dummy");

                b.Property<int?>("entity_group_id");

                b.Property<int?>("field_id");

                b.Property<int?>("field_type_id");

                b.Property<short?>("geolocation_enabled");

                b.Property<short?>("geolocation_forced");

                b.Property<short?>("geolocation_hidden");

                b.Property<short?>("is_num");

                b.Property<string>("key_value_pair_list");

                b.Property<string>("label");

                b.Property<short?>("mandatory");

                b.Property<int?>("max_length");

                b.Property<string>("max_value")
                    .HasMaxLength(255);

                b.Property<string>("min_value")
                    .HasMaxLength(255);

                b.Property<int?>("multi");

                b.Property<short?>("optional");

                b.Property<int?>("parent_field_id");

                b.Property<string>("query_type")
                    .HasMaxLength(255);

                b.Property<short?>("read_only");

                b.Property<short?>("selected");

                b.Property<short?>("split_screen");

                b.Property<short?>("stop_on_save");

                b.Property<string>("unit_name")
                    .HasMaxLength(255);

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("field_versions");
            });

            modelBuilder.Entity("eFormSqlController.fields", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<short?>("barcode_enabled");

                b.Property<string>("barcode_type")
                    .HasMaxLength(255);

                b.Property<int?>("check_list_id");

                b.Property<string>("color")
                    .HasMaxLength(255);

                b.Property<DateTime?>("created_at");

                b.Property<string>("custom");

                b.Property<int?>("decimal_count");

                b.Property<string>("default_value");

                b.Property<string>("description");

                b.Property<int?>("display_index");

                b.Property<short?>("dummy");

                b.Property<int?>("entity_group_id");

                b.Property<int?>("field_type_id");

                b.Property<short?>("geolocation_enabled");

                b.Property<short?>("geolocation_forced");

                b.Property<short?>("geolocation_hidden");

                b.Property<short?>("is_num");

                b.Property<string>("key_value_pair_list");

                b.Property<string>("label");

                b.Property<short?>("mandatory");

                b.Property<int?>("max_length");

                b.Property<string>("max_value")
                    .HasMaxLength(255);

                b.Property<string>("min_value")
                    .HasMaxLength(255);

                b.Property<int?>("multi");

                b.Property<short?>("optional");

                b.Property<int?>("parent_field_id");

                b.Property<int?>("parentid");

                b.Property<string>("query_type")
                    .HasMaxLength(255);

                b.Property<short?>("read_only");

                b.Property<short?>("selected");

                b.Property<short?>("split_screen");

                b.Property<short?>("stop_on_save");

                b.Property<string>("unit_name")
                    .HasMaxLength(255);

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.HasIndex("check_list_id");

                b.HasIndex("field_type_id");

                b.HasIndex("parentid");

                b.ToTable("fields");
            });

            modelBuilder.Entity("eFormSqlController.log_exceptions", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                     .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<DateTime>("created_at");

                b.Property<int>("level");

                b.Property<string>("message");

                b.Property<string>("type");

                b.HasKey("id");

                b.ToTable("log_exceptions");
            });

            modelBuilder.Entity("eFormSqlController.logs", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                     .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<DateTime>("created_at");

                b.Property<int>("level");

                b.Property<string>("message");

                b.Property<string>("type");

                b.HasKey("id");

                b.ToTable("logs");
            });

            modelBuilder.Entity("eFormSqlController.notifications", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                     .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<string>("activity");

                b.Property<DateTime?>("created_at");

                b.Property<string>("exception");

                b.Property<string>("microting_uid")
                    .HasMaxLength(255);

                b.Property<string>("notification_uid")
                    .HasMaxLength(255);

                b.Property<string>("stacktrace");

                b.Property<string>("transmission");

                b.Property<DateTime?>("updated_at");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("notifications");
            });

            modelBuilder.Entity("eFormSqlController.settings", b =>
            {
                b.Property<int>("id");

                b.Property<string>("name")
                    .IsRequired()
                    .HasMaxLength(50);

                b.Property<string>("value");

                b.HasKey("id");

                b.ToTable("settings");
            });

            modelBuilder.Entity("eFormSqlController.site_versions", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<DateTime?>("created_at");

                b.Property<int?>("microting_uid");

                b.Property<string>("name")
                    .HasMaxLength(255);

                b.Property<int?>("site_id");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("site_versions");
            });

            modelBuilder.Entity("eFormSqlController.site_worker_versions", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                     .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<DateTime?>("created_at");

                b.Property<int?>("microting_uid");

                b.Property<int?>("site_id");

                b.Property<int?>("site_worker_id");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<int?>("worker_id");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("site_worker_versions");
            });

            modelBuilder.Entity("eFormSqlController.site_workers", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<DateTime?>("created_at");

                b.Property<int?>("microting_uid");

                b.Property<int?>("site_id");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<int?>("worker_id");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.HasIndex("site_id");

                b.HasIndex("worker_id");

                b.ToTable("site_workers");
            });

            modelBuilder.Entity("eFormSqlController.sites", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<DateTime?>("created_at");

                b.Property<int?>("microting_uid");

                b.Property<string>("name")
                    .HasMaxLength(255);

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("sites");
            });

            modelBuilder.Entity("eFormSqlController.tag_versions", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<DateTime?>("created_at");

                b.Property<string>("name")
                    .HasMaxLength(255);

                b.Property<int?>("tag_id");

                b.Property<int?>("taggings_count");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("tag_versions");
            });

            modelBuilder.Entity("eFormSqlController.tagging_versions", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                     .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<int?>("check_list_id");

                b.Property<DateTime?>("created_at");

                b.Property<int?>("tag_id");

                b.Property<int?>("tagger_id");

                b.Property<int?>("tagging_id");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("tagging_versions");
            });

            modelBuilder.Entity("eFormSqlController.taggings", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<int?>("check_list_id");

                b.Property<DateTime?>("created_at");

                b.Property<int?>("tag_id");

                b.Property<int?>("tagger_id");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.HasIndex("check_list_id");

                b.HasIndex("tag_id");

                b.ToTable("taggings");
            });

            modelBuilder.Entity("eFormSqlController.tags", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<DateTime?>("created_at");

                b.Property<string>("name")
                    .HasMaxLength(255);

                b.Property<int?>("taggings_count");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("tags");
            });

            modelBuilder.Entity("eFormSqlController.unit_versions", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<DateTime?>("created_at");

                b.Property<int?>("customer_no");

                b.Property<int?>("microting_uid");

                b.Property<int?>("otp_code");

                b.Property<int?>("site_id");

                b.Property<int?>("unit_id");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("unit_versions");
            });

            modelBuilder.Entity("eFormSqlController.units", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                     .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<DateTime?>("created_at");

                b.Property<int?>("customer_no");

                b.Property<int?>("microting_uid");

                b.Property<int?>("otp_code");

                b.Property<int?>("site_id");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.HasIndex("site_id");

                b.ToTable("units");
            });

            modelBuilder.Entity("eFormSqlController.uploaded_data", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<string>("checksum")
                    .HasMaxLength(255);

                b.Property<DateTime?>("created_at");

                b.Property<string>("current_file")
                    .HasMaxLength(255);

                b.Property<DateTime?>("expiration_date");

                b.Property<string>("extension")
                    .HasMaxLength(255);

                b.Property<string>("file_location")
                    .HasMaxLength(255);

                b.Property<string>("file_name")
                    .HasMaxLength(255);

                b.Property<short?>("local");

                b.Property<int?>("transcription_id");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("uploader_id");

                b.Property<string>("uploader_type")
                    .HasMaxLength(255);

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("uploaded_data");
            });

            modelBuilder.Entity("eFormSqlController.uploaded_data_versions", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<string>("checksum")
                    .HasMaxLength(255);

                b.Property<DateTime?>("created_at");

                b.Property<string>("current_file")
                    .HasMaxLength(255);

                b.Property<int?>("data_uploaded_id");

                b.Property<DateTime?>("expiration_date");

                b.Property<string>("extension")
                    .HasMaxLength(255);

                b.Property<string>("file_location")
                    .HasMaxLength(255);

                b.Property<string>("file_name")
                    .HasMaxLength(255);

                b.Property<short?>("local");

                b.Property<int?>("transcription_id");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("uploader_id");

                b.Property<string>("uploader_type")
                    .HasMaxLength(255);

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("uploaded_data_versions");
            });

            modelBuilder.Entity("eFormSqlController.worker_versions", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                    .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<DateTime?>("created_at");

                b.Property<string>("email")
                    .HasMaxLength(255);

                b.Property<string>("first_name")
                    .HasMaxLength(255);

                b.Property<string>("last_name")
                    .HasMaxLength(255);

                b.Property<int>("microting_uid");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<int?>("worker_id");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("worker_versions");
            });

            modelBuilder.Entity("eFormSqlController.workers", b =>
            {
                b.Property<int>("id")
                    .ValueGeneratedOnAdd()
                     .HasAnnotation("MySQL:ValueGeneratedOnAdd", true);

                b.Property<DateTime?>("created_at");

                b.Property<string>("email")
                    .HasMaxLength(255);

                b.Property<string>("first_name")
                    .HasMaxLength(255);

                b.Property<string>("last_name")
                    .HasMaxLength(255);

                b.Property<int>("microting_uid");

                b.Property<DateTime?>("updated_at");

                b.Property<int?>("version");

                b.Property<string>("workflow_state")
                    .HasMaxLength(255);

                b.HasKey("id");

                b.ToTable("workers");
            });

            modelBuilder.Entity("eFormSqlController.cases", b =>
            {
                b.HasOne("eFormSqlController.check_lists", "check_list")
                    .WithMany("cases")
                    .HasForeignKey("check_list_id");

                b.HasOne("eFormSqlController.workers", "worker")
                    .WithMany()
                    .HasForeignKey("done_by_user_id");

                b.HasOne("eFormSqlController.sites", "site")
                    .WithMany("cases")
                    .HasForeignKey("site_id");

                b.HasOne("eFormSqlController.units", "unit")
                    .WithMany()
                    .HasForeignKey("unit_id");
            });

            modelBuilder.Entity("eFormSqlController.check_list_sites", b =>
            {
                b.HasOne("eFormSqlController.check_lists", "check_list")
                    .WithMany("check_list_sites")
                    .HasForeignKey("check_list_id");

                b.HasOne("eFormSqlController.sites", "site")
                    .WithMany("check_list_sites")
                    .HasForeignKey("site_id");
            });

            modelBuilder.Entity("eFormSqlController.check_lists", b =>
            {
                b.HasOne("eFormSqlController.check_lists", "parent")
                    .WithMany("children")
                    .HasForeignKey("parentid");

                //b.HasOne("eFormSqlController.tags")
                //    .WithMany("check_lists")
                //    .HasForeignKey("tagsid");
            });

            modelBuilder.Entity("eFormSqlController.field_values", b =>
            {
                b.HasOne("eFormSqlController.check_lists", "check_list")
                    .WithMany()
                    .HasForeignKey("check_list_id");

                b.HasOne("eFormSqlController.fields", "field")
                    .WithMany("field_values")
                    .HasForeignKey("field_id");

                b.HasOne("eFormSqlController.uploaded_data", "uploaded_data")
                    .WithMany()
                    .HasForeignKey("uploaded_data_id");

                b.HasOne("eFormSqlController.workers", "worker")
                    .WithMany()
                    .HasForeignKey("user_id");
            });

            modelBuilder.Entity("eFormSqlController.fields", b =>
            {
                b.HasOne("eFormSqlController.check_lists", "check_list")
                    .WithMany("fields")
                    .HasForeignKey("check_list_id");

                b.HasOne("eFormSqlController.field_types", "field_type")
                    .WithMany()
                    .HasForeignKey("field_type_id");

                b.HasOne("eFormSqlController.fields", "parent")
                    .WithMany("children")
                    .HasForeignKey("parentid");
            });

            modelBuilder.Entity("eFormSqlController.site_workers", b =>
            {
                b.HasOne("eFormSqlController.sites", "site")
                    .WithMany("site_workers")
                    .HasForeignKey("site_id");

                b.HasOne("eFormSqlController.workers", "worker")
                    .WithMany("site_workers")
                    .HasForeignKey("worker_id");
            });

            modelBuilder.Entity("eFormSqlController.taggings", b =>
            {
                b.HasOne("eFormSqlController.check_lists", "check_list")
                    .WithMany("taggings")
                    .HasForeignKey("check_list_id");

                b.HasOne("eFormSqlController.tags", "tag")
                    .WithMany("taggings")
                    .HasForeignKey("tag_id");
            });

            modelBuilder.Entity("eFormSqlController.units", b =>
            {
                b.HasOne("eFormSqlController.sites", "site")
                    .WithMany("units")
                    .HasForeignKey("site_id");
            });
#pragma warning restore 612, 618
        }
    }
}