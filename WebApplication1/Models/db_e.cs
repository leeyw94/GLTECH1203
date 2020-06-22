using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GLtech.Models
{
    public partial class db_e : DbContext
    {
        public db_e()
        {
        }

        public db_e(DbContextOptions<db_e> options)
            : base(options)
        {
        }

        public virtual DbSet<BoardCode> BoardCode { get; set; }
        public virtual DbSet<BoardComment> BoardComment { get; set; }
        public virtual DbSet<BoardFile> BoardFile { get; set; }
        public virtual DbSet<BoardList> BoardList { get; set; }
        public virtual DbSet<BoardMenu> BoardMenu { get; set; }
        public virtual DbSet<BoardRread> BoardRread { get; set; }
        public virtual DbSet<CategoryMenus> CategoryMenus { get; set; }
        public virtual DbSet<Downloader> Downloader { get; set; }
        public virtual DbSet<Inquiry> Inquiry { get; set; }
        public virtual DbSet<Main_data> Main_data { get; set; }
        public virtual DbSet<Md_Image> Md_Image { get; set; }
        public virtual DbSet<alert_error> alert_error { get; set; }
        public virtual DbSet<alert_member> alert_member { get; set; }
        public virtual DbSet<code_company> code_company { get; set; }
        public virtual DbSet<code_index> code_index { get; set; }
        public virtual DbSet<code_machine> code_machine { get; set; }
        public virtual DbSet<code_nationality> code_nationality { get; set; }
        public virtual DbSet<code_production> code_production { get; set; }
        public virtual DbSet<code_project_state> code_project_state { get; set; }
        public virtual DbSet<company> company { get; set; }
        public virtual DbSet<department> department { get; set; }
        public virtual DbSet<error_type> error_type { get; set; }
        public virtual DbSet<event_list> event_list { get; set; }
        public virtual DbSet<history> history { get; set; }
        public virtual DbSet<language> language { get; set; }
        public virtual DbSet<machine> machine { get; set; }
        public virtual DbSet<photo> photo { get; set; }
        public virtual DbSet<project_main> project_main { get; set; }
        public virtual DbSet<sensor_data> sensor_data { get; set; }
        public virtual DbSet<sensor_event> sensor_event { get; set; }
        public virtual DbSet<sensor_event_log> sensor_event_log { get; set; }
        public virtual DbSet<sensor_set> sensor_set { get; set; }
        public virtual DbSet<service> service { get; set; }
        public virtual DbSet<sms_list> sms_list { get; set; }
        public virtual DbSet<sms_time> sms_time { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<work_list> work_list { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:180.210.34.49,1433;Initial Catalog=admin_basic;Persist Security Info=True;User ID=blueeye;Password=blueeye0037;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=True;Connection Timeout=300;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoardCode>(entity =>
            {
                entity.Property(e => e.board_auth).IsUnicode(false);

                entity.Property(e => e.code_name)
                    .IsUnicode(false)
                    .HasComment("중류");

                entity.Property(e => e.gubun).IsUnicode(false);

                entity.Property(e => e.use_yn).IsUnicode(false);
            });

            modelBuilder.Entity<BoardComment>(entity =>
            {
                entity.HasKey(e => e.idx)
                    .HasName("PK_bbs_comment");

                entity.Property(e => e.edit_date).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.step).HasDefaultValueSql("((1))");

                entity.Property(e => e.use_yn).IsUnicode(false);

                entity.Property(e => e.user_ip).IsUnicode(false);

                entity.Property(e => e.write_date).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.writer).IsUnicode(false);

                entity.HasOne(d => d.BD_idxNavigation)
                    .WithMany(p => p.BoardComment)
                    .HasForeignKey(d => d.BD_idx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BoardComment_Board");
            });

            modelBuilder.Entity<BoardFile>(entity =>
            {
                entity.Property(e => e.ImagePath).IsUnicode(false);

                entity.Property(e => e.Md_id)
                    .IsUnicode(false)
                    .HasComment("파일 고유 키");

                entity.Property(e => e.fileName).IsUnicode(false);

                entity.Property(e => e.file_ex).IsUnicode(false);

                entity.Property(e => e.memo).IsUnicode(false);

                entity.Property(e => e.sImagePath).IsUnicode(false);

                entity.Property(e => e.title).IsUnicode(false);

                entity.Property(e => e.use_yn).IsUnicode(false);

                entity.Property(e => e.write_id).IsUnicode(false);
            });

            modelBuilder.Entity<BoardList>(entity =>
            {
                entity.HasKey(e => e.idx)
                    .HasName("PK_Board");

                entity.Property(e => e.BM_idx).HasComment("게시판 메뉴 인덱스");

                entity.Property(e => e.delDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("삭제일");

                entity.Property(e => e.editDate)
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("수정일");

                entity.Property(e => e.fileId).IsUnicode(false);

                entity.Property(e => e.main_yn)
                    .IsUnicode(false)
                    .HasComment("메인 노출 (y,n)");

                entity.Property(e => e.password).IsUnicode(false);

                entity.Property(e => e.title).IsUnicode(false);

                entity.Property(e => e.useable)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((1))")
                    .HasComment("게시글 사용 여부 (Y/N)");

                entity.Property(e => e.writeDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.writer).IsUnicode(false);

                entity.HasOne(d => d.BM_idxNavigation)
                    .WithMany(p => p.BoardList)
                    .HasForeignKey(d => d.BM_idx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BoardList_BoardMenu");
            });

            modelBuilder.Entity<BoardMenu>(entity =>
            {
                entity.Property(e => e.BoardType_idx).HasComment("게시판 종류");

                entity.Property(e => e.index_order).HasDefaultValueSql("((999))");

                entity.Property(e => e.open_yn).IsUnicode(false);

                entity.Property(e => e.title).IsUnicode(false);

                entity.Property(e => e.url).IsUnicode(false);

                entity.HasOne(d => d.BoardType_idxNavigation)
                    .WithMany(p => p.BoardMenu)
                    .HasForeignKey(d => d.BoardType_idx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BoardMenu_BoardCode");

                entity.HasOne(d => d.company_idxNavigation)
                    .WithMany(p => p.BoardMenu)
                    .HasForeignKey(d => d.company_idx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BoardMenu_company");

                entity.HasOne(d => d.department_idxNavigation)
                    .WithMany(p => p.BoardMenu)
                    .HasForeignKey(d => d.department_idx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BoardMenu_department");
            });

            modelBuilder.Entity<BoardRread>(entity =>
            {
                entity.HasKey(e => e.idx)
                    .HasName("PK_board_read");

                entity.Property(e => e.user_id).IsUnicode(false);

                entity.Property(e => e.user_name).IsUnicode(false);

                entity.HasOne(d => d.board_idxNavigation)
                    .WithMany(p => p.BoardRread)
                    .HasForeignKey(d => d.board_idx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BoardRread_Board");

                entity.HasOne(d => d.user_)
                    .WithMany(p => p.BoardRread)
                    .HasForeignKey(d => d.user_id)
                    .HasConstraintName("FK_BoardRread_user");
            });

            modelBuilder.Entity<CategoryMenus>(entity =>
            {
                entity.Property(e => e.company_id).IsUnicode(false);

                entity.Property(e => e.step_auth).IsUnicode(false);

                entity.Property(e => e.step_dept).HasDefaultValueSql("((1))");

                entity.Property(e => e.step_icon).IsUnicode(false);

                entity.Property(e => e.step_index)
                    .IsUnicode(false)
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.step_name).IsUnicode(false);

                entity.Property(e => e.step_orderby).HasDefaultValueSql("((9))");

                entity.Property(e => e.step_url1).IsUnicode(false);

                entity.Property(e => e.step_url2).IsUnicode(false);

                entity.Property(e => e.step_writedate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Downloader>(entity =>
            {
                entity.Property(e => e.email).IsUnicode(false);

                entity.Property(e => e.name).IsUnicode(false);

                entity.Property(e => e.tel).IsUnicode(false);

                entity.Property(e => e.write_date).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Inquiry>(entity =>
            {
                entity.Property(e => e.company).IsUnicode(false);

                entity.Property(e => e.contents).IsUnicode(false);

                entity.Property(e => e.department).IsUnicode(false);

                entity.Property(e => e.email).IsUnicode(false);

                entity.Property(e => e.name).IsUnicode(false);

                entity.Property(e => e.tel).IsUnicode(false);

                entity.Property(e => e.writeDate).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Main_data>(entity =>
            {
                entity.Property(e => e.check_use).IsUnicode(false);

                entity.Property(e => e.firm).IsUnicode(false);

                entity.Property(e => e.h_level)
                    .HasDefaultValueSql("((-1))")
                    .HasComment("고수위 설정");

                entity.Property(e => e.in_date).HasComment("장비 제공 시간");

                entity.Property(e => e.index_order).HasDefaultValueSql("((1))");

                entity.Property(e => e.l_level)
                    .HasDefaultValueSql("((-1))")
                    .HasComment("저수위 설정");

                entity.Property(e => e.pump_state)
                    .IsUnicode(false)
                    .HasComment("펌프 on off");

                entity.Property(e => e.r_battery)
                    .IsUnicode(false)
                    .HasComment("수신부 배터리 상태");

                entity.Property(e => e.r_power_state)
                    .IsUnicode(false)
                    .HasComment("수신부 전원상태");

                entity.Property(e => e.rf_id)
                    .IsUnicode(false)
                    .HasComment("RF ID");

                entity.Property(e => e.rf_state)
                    .IsUnicode(false)
                    .HasComment("RF 통신 상태");

                entity.Property(e => e.rowdata).IsUnicode(false);

                entity.Property(e => e.run_state)
                    .IsUnicode(false)
                    .HasComment("운전상태");

                entity.Property(e => e.sensor_state)
                    .IsUnicode(false)
                    .HasComment("수위센서 상태");

                entity.Property(e => e.sensor_type)
                    .IsUnicode(false)
                    .HasComment("수위 센서 타입");

                entity.Property(e => e.shop_id).IsUnicode(false);

                entity.Property(e => e.t_battery)
                    .IsUnicode(false)
                    .HasComment("송신부 배터리 상태");

                entity.Property(e => e.w_level)
                    .HasDefaultValueSql("((-1))")
                    .HasComment("현재수위");

                entity.Property(e => e.w_type)
                    .IsUnicode(false)
                    .HasComment(" O4(무선 수위조절기->서버) 타입");

                entity.Property(e => e.write_date)
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("접속 시간");
            });

            modelBuilder.Entity<Md_Image>(entity =>
            {
                entity.Property(e => e.ImagePath).IsUnicode(false);

                entity.Property(e => e.Md_id).IsUnicode(false);

                entity.Property(e => e.fileName).IsUnicode(false);

                entity.Property(e => e.file_ex).IsUnicode(false);

                entity.Property(e => e.file_size).HasDefaultValueSql("((0))");

                entity.Property(e => e.index_order).HasDefaultValueSql("((999))");

                entity.Property(e => e.sImagePath).IsUnicode(false);

                entity.Property(e => e.use_yn).IsUnicode(false);

                entity.Property(e => e.write_id).IsUnicode(false);
            });

            modelBuilder.Entity<alert_error>(entity =>
            {
                entity.Property(e => e.error_memo).IsUnicode(false);

                entity.Property(e => e.error_type_int).HasComment("접속 에러");

                entity.Property(e => e.send_state).IsUnicode(false);

                entity.Property(e => e.send_state_memo).IsUnicode(false);

                entity.Property(e => e.shop_id).IsUnicode(false);

                entity.Property(e => e.work_date).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.error_type_intNavigation)
                    .WithMany(p => p.alert_error)
                    .HasForeignKey(d => d.error_type_int)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_alert_error_error_type");
            });

            modelBuilder.Entity<alert_member>(entity =>
            {
                entity.Property(e => e.alert_night)
                    .IsUnicode(false)
                    .HasComment("야간 경보");

                entity.Property(e => e.alert_type)
                    .IsUnicode(false)
                    .HasComment("경보 타입");

                entity.Property(e => e.use_id).IsUnicode(false);

                entity.Property(e => e.use_yn).IsUnicode(false);

                entity.Property(e => e.user_hp).IsUnicode(false);

                entity.Property(e => e.user_name).IsUnicode(false);
            });

            modelBuilder.Entity<code_company>(entity =>
            {
                entity.Property(e => e.code_name).IsUnicode(false);

                entity.Property(e => e.gubun).IsUnicode(false);

                entity.Property(e => e.use_yn).IsUnicode(false);
            });

            modelBuilder.Entity<code_index>(entity =>
            {
                entity.Property(e => e.code_name).IsUnicode(false);

                entity.Property(e => e.gubun).IsUnicode(false);

                entity.Property(e => e.use_yn).IsUnicode(false);
            });

            modelBuilder.Entity<code_machine>(entity =>
            {
                entity.Property(e => e.code_name).IsUnicode(false);

                entity.Property(e => e.gubun).IsUnicode(false);

                entity.Property(e => e.use_yn).IsUnicode(false);
            });

            modelBuilder.Entity<code_nationality>(entity =>
            {
                entity.HasKey(e => e.code_id)
                    .HasName("PK_code_1");

                entity.Property(e => e.code_id).IsUnicode(false);

                entity.Property(e => e.gubun).IsUnicode(false);

                entity.Property(e => e.use_yn).IsUnicode(false);

                entity.Property(e => e.write_date).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.writer_id).IsUnicode(false);
            });

            modelBuilder.Entity<code_production>(entity =>
            {
                entity.Property(e => e.code_name).IsUnicode(false);

                entity.Property(e => e.gubun).IsUnicode(false);

                entity.Property(e => e.use_yn).IsUnicode(false);
            });

            modelBuilder.Entity<code_project_state>(entity =>
            {
                entity.Property(e => e.code_id).ValueGeneratedNever();

                entity.Property(e => e.code_name).IsUnicode(false);

                entity.Property(e => e.gubun).IsUnicode(false);

                entity.Property(e => e.use_yn).IsUnicode(false);
            });

            modelBuilder.Entity<company>(entity =>
            {
                entity.HasKey(e => e.idx)
                    .HasName("PK_company_1");

                entity.Property(e => e.company_id)
                    .IsUnicode(false)
                    .HasComment("회사 아이디");

                entity.Property(e => e.company_name)
                    .IsUnicode(false)
                    .HasComment("회사명");

                entity.Property(e => e.index_order).HasDefaultValueSql("((99))");

                entity.Property(e => e.nationality)
                    .IsUnicode(false)
                    .HasComment("국적 코드");

                entity.Property(e => e.use_yn)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.write_date).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.code_company_idxNavigation)
                    .WithMany(p => p.company)
                    .HasForeignKey(d => d.code_company_idx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_company_code_company");
            });

            modelBuilder.Entity<department>(entity =>
            {
                entity.HasKey(e => e.idx)
                    .HasName("PK_department_1");

                entity.Property(e => e.department_auth)
                    .IsUnicode(false)
                    .HasComment("부서 권한");

                entity.Property(e => e.department_name)
                    .IsUnicode(false)
                    .HasComment("부서명");

                entity.Property(e => e.index_order).HasDefaultValueSql("((99))");

                entity.Property(e => e.use_yn)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.write_date).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.company_idxNavigation)
                    .WithMany(p => p.department)
                    .HasForeignKey(d => d.company_idx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_department_company");
            });

            modelBuilder.Entity<error_type>(entity =>
            {
                entity.Property(e => e.code_id).ValueGeneratedNever();

                entity.Property(e => e.code_name).IsUnicode(false);
            });

            modelBuilder.Entity<event_list>(entity =>
            {
                entity.Property(e => e.f_city)
                    .IsUnicode(false)
                    .HasComment("도시");

                entity.Property(e => e.f_name).IsUnicode(false);

                entity.Property(e => e.f_nation_id).HasComment("주최국가");

                entity.Property(e => e.index_order).HasDefaultValueSql("((999))");

                entity.Property(e => e.r_date)
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("행사일");

                entity.Property(e => e.use_yn).IsUnicode(false);
            });

            modelBuilder.Entity<history>(entity =>
            {
                entity.Property(e => e.company_id).IsUnicode(false);

                entity.Property(e => e.connect_agent).IsUnicode(false);

                entity.Property(e => e.connect_date).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.connect_host).IsUnicode(false);

                entity.Property(e => e.connect_path).IsUnicode(false);

                entity.Property(e => e.department_id).IsUnicode(false);

                entity.Property(e => e.memo).IsUnicode(false);

                entity.Property(e => e.page).IsUnicode(false);

                entity.Property(e => e.pre_page).IsUnicode(false);

                entity.Property(e => e.state).IsUnicode(false);

                entity.Property(e => e.user_id).IsUnicode(false);

                entity.Property(e => e.user_ip).IsUnicode(false);

                entity.HasOne(d => d.user_)
                    .WithMany(p => p.history)
                    .HasForeignKey(d => d.user_id)
                    .HasConstraintName("FK_history_user");
            });

            modelBuilder.Entity<language>(entity =>
            {
                entity.Property(e => e.code_name).IsUnicode(false);

                entity.Property(e => e.english).IsUnicode(false);

                entity.Property(e => e.idx).ValueGeneratedOnAdd();

                entity.Property(e => e.korea).IsUnicode(false);
            });

            modelBuilder.Entity<machine>(entity =>
            {
                entity.Property(e => e.machine_id).IsUnicode(false);

                entity.Property(e => e.addr).IsUnicode(false);

                entity.Property(e => e.check_use).IsUnicode(false);

                entity.Property(e => e.company_id).IsUnicode(false);

                entity.Property(e => e.company_idx).HasDefaultValueSql("((1))");

                entity.Property(e => e.edit_date).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.file_sn).IsUnicode(false);

                entity.Property(e => e.h_level)
                    .HasDefaultValueSql("((-1))")
                    .HasComment("고수위 설정");

                entity.Property(e => e.idx).ValueGeneratedOnAdd();

                entity.Property(e => e.in_date).HasComment("장비 제공 시간");

                entity.Property(e => e.index_order).HasDefaultValueSql("((1))");

                entity.Property(e => e.l_level)
                    .HasDefaultValueSql("((-1))")
                    .HasComment("저수위 설정");

                entity.Property(e => e.machine_name).IsUnicode(false);

                entity.Property(e => e.pump_state)
                    .IsUnicode(false)
                    .HasComment("펌프 on off");

                entity.Property(e => e.r_battery)
                    .IsUnicode(false)
                    .HasComment("수신부 배터리 상태");

                entity.Property(e => e.r_power_state)
                    .IsUnicode(false)
                    .HasComment("수신부 전원상태");

                entity.Property(e => e.rf_id)
                    .IsUnicode(false)
                    .HasComment("RF ID");

                entity.Property(e => e.rf_state)
                    .IsUnicode(false)
                    .HasComment("RF 통신 상태");

                entity.Property(e => e.run_state)
                    .IsUnicode(false)
                    .HasComment("운전상태");

                entity.Property(e => e.sensor_state)
                    .IsUnicode(false)
                    .HasComment("수위센서 상태");

                entity.Property(e => e.sensor_type)
                    .IsUnicode(false)
                    .HasComment("수위 센서 타입");

                entity.Property(e => e.t_battery)
                    .IsUnicode(false)
                    .HasComment("송신부 배터리 상태");

                entity.Property(e => e.use_yn)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.w_level)
                    .HasDefaultValueSql("((-1))")
                    .HasComment("현재수위");

                entity.Property(e => e.write_date).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.writer_id).IsUnicode(false);

                entity.Property(e => e.x_position).IsUnicode(false);

                entity.Property(e => e.y_position).IsUnicode(false);

                entity.HasOne(d => d.code_machine_idxNavigation)
                    .WithMany(p => p.machine)
                    .HasForeignKey(d => d.code_machine_idx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_machine_code_machine");

                entity.HasOne(d => d.company_idxNavigation)
                    .WithMany(p => p.machine)
                    .HasForeignKey(d => d.company_idx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_machine_company");

                entity.HasOne(d => d.writer_)
                    .WithMany(p => p.machine)
                    .HasForeignKey(d => d.writer_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_machine_user");
            });

            modelBuilder.Entity<photo>(entity =>
            {
                entity.Property(e => e.ImagePath).IsUnicode(false);

                entity.Property(e => e.M_Category).HasComment("대회종류");

                entity.Property(e => e.M_gubun).IsUnicode(false);

                entity.Property(e => e.M_keyword).IsUnicode(false);

                entity.Property(e => e.M_season).HasComment("대회 시즌");

                entity.Property(e => e.code_city_id).HasComment("소속 도시");

                entity.Property(e => e.index_order).HasDefaultValueSql("((999))");

                entity.Property(e => e.sImagePath).IsUnicode(false);

                entity.Property(e => e.title).IsUnicode(false);

                entity.Property(e => e.title_en).IsUnicode(false);

                entity.Property(e => e.use_yn).IsUnicode(false);

                entity.Property(e => e.write_id).IsUnicode(false);

                entity.HasOne(d => d.M_seasonNavigation)
                    .WithMany(p => p.photo)
                    .HasForeignKey(d => d.M_season)
                    .HasConstraintName("FK_photo_event_list");
            });

            modelBuilder.Entity<project_main>(entity =>
            {
                entity.Property(e => e.company_id).IsUnicode(false);

                entity.Property(e => e.department_id).IsUnicode(false);

                entity.Property(e => e.end_date).HasComment("종료일");

                entity.Property(e => e.index_order).HasDefaultValueSql("((9))");

                entity.Property(e => e.memo).IsUnicode(false);

                entity.Property(e => e.project_code).IsUnicode(false);

                entity.Property(e => e.project_name)
                    .IsUnicode(false)
                    .HasComment("프로젝트 이름");

                entity.Property(e => e.start_date).HasComment("시작일");

                entity.Property(e => e.state)
                    .HasDefaultValueSql("((1))")
                    .HasComment("진행상태(준비중,진행중 등)");

                entity.Property(e => e.use_yn)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.write_date).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.writer).IsUnicode(false);
            });

            modelBuilder.Entity<sensor_data>(entity =>
            {
                entity.Property(e => e.machine_id).IsUnicode(false);

                entity.HasOne(d => d.machine_)
                    .WithMany(p => p.sensor_data)
                    .HasForeignKey(d => d.machine_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sensor_data_sensor_set");
            });

            modelBuilder.Entity<sensor_event>(entity =>
            {
                entity.Property(e => e.name).IsUnicode(false);
            });

            modelBuilder.Entity<sensor_event_log>(entity =>
            {
                entity.Property(e => e.machine_id).IsUnicode(false);

                entity.HasOne(d => d.event_)
                    .WithMany(p => p.sensor_event_log)
                    .HasForeignKey(d => d.event_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sensor_event_log_sensor_event");

                entity.HasOne(d => d.machine_)
                    .WithMany(p => p.sensor_event_log)
                    .HasForeignKey(d => d.machine_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sensor_event_log_machine");
            });

            modelBuilder.Entity<sensor_set>(entity =>
            {
                entity.Property(e => e.machine_id).IsUnicode(false);

                entity.Property(e => e.cam_host).IsUnicode(false);

                entity.Property(e => e.cam_pts).IsUnicode(false);
            });

            modelBuilder.Entity<service>(entity =>
            {
                entity.Property(e => e.cad_time).HasComment("cad 시간");

                entity.Property(e => e.cam_time).HasComment("cam  시간");

                entity.Property(e => e.edit_date)
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("수정일");

                entity.Property(e => e.end_date).HasComment("납기일");

                entity.Property(e => e.file_sn).IsUnicode(false);

                entity.Property(e => e.finish_date).HasComment("납품일");

                entity.Property(e => e.gas_coaxial).HasComment("가스량 COAXIAL");

                entity.Property(e => e.gas_powder).HasComment("가스 파우더");

                entity.Property(e => e.gas_shield).HasComment("가스량");

                entity.Property(e => e.gipan)
                    .IsUnicode(false)
                    .HasComment("기판(소재 및크기)");

                entity.Property(e => e.guest_id)
                    .IsUnicode(false)
                    .HasComment("거래처");

                entity.Property(e => e.lotno)
                    .IsUnicode(false)
                    .HasComment("Lot No");

                entity.Property(e => e.machine_id).IsUnicode(false);

                entity.Property(e => e.main_memo).IsUnicode(false);

                entity.Property(e => e.out_date).HasComment("발주일자");

                entity.Property(e => e.photo_1).IsUnicode(false);

                entity.Property(e => e.photo_2).IsUnicode(false);

                entity.Property(e => e.photo_3).IsUnicode(false);

                entity.Property(e => e.photo_4).IsUnicode(false);

                entity.Property(e => e.powder_id).HasComment("분말소재");

                entity.Property(e => e.powder_quantity).HasComment("분말량");

                entity.Property(e => e.powder_use)
                    .IsUnicode(false)
                    .HasComment("분말사용량");

                entity.Property(e => e.process_memo)
                    .IsUnicode(false)
                    .HasComment("공정 메모");

                entity.Property(e => e.product_name).IsUnicode(false);

                entity.Property(e => e.production_code).HasComment("제작 (단일소재,다소재제작 등)");

                entity.Property(e => e.quantity).HasDefaultValueSql("((0))");

                entity.Property(e => e.result_yn)
                    .IsUnicode(false)
                    .HasComment("결과여부");

                entity.Property(e => e.service_sp)
                    .IsUnicode(false)
                    .HasComment("SP NUMBER");

                entity.Property(e => e.setting_time).HasComment("setting 시간");

                entity.Property(e => e.sojae_id).HasComment("분말소재");

                entity.Property(e => e.work_end_date).HasComment("작업종료일");

                entity.Property(e => e.work_memo)
                    .IsUnicode(false)
                    .HasComment("제작 메모");

                entity.Property(e => e.work_start_date).HasComment("작업시작일");

                entity.Property(e => e.work_time).HasComment("작업시간");

                entity.Property(e => e.write_date)
                    .HasDefaultValueSql("(getdate())")
                    .HasComment("작성일");

                entity.Property(e => e.writer)
                    .IsUnicode(false)
                    .HasComment("작성자");

                entity.HasOne(d => d.production_codeNavigation)
                    .WithMany(p => p.service)
                    .HasForeignKey(d => d.production_code)
                    .HasConstraintName("FK_service_code_production");
            });

            modelBuilder.Entity<sms_list>(entity =>
            {
                entity.Property(e => e.shop_id).IsUnicode(false);

                entity.Property(e => e.who).IsUnicode(false);

                entity.HasOne(d => d.error_type_intNavigation)
                    .WithMany(p => p.sms_list)
                    .HasForeignKey(d => d.error_type_int)
                    .HasConstraintName("FK_sms_list_error_type");

                entity.HasOne(d => d.shop_)
                    .WithMany(p => p.sms_list)
                    .HasForeignKey(d => d.shop_id)
                    .HasConstraintName("FK_sms_list_machine");
            });

            modelBuilder.Entity<sms_time>(entity =>
            {
                entity.Property(e => e.idx).ValueGeneratedNever();

                entity.Property(e => e.shop_id).IsUnicode(false);

                entity.Property(e => e.sms_time_set).HasDefaultValueSql("((60))");
            });

            modelBuilder.Entity<user>(entity =>
            {
                entity.Property(e => e.user_id)
                    .IsUnicode(false)
                    .HasComment("사용자 아이디");

                entity.Property(e => e.check_auth).HasDefaultValueSql("((1))");

                entity.Property(e => e.company_id)
                    .IsUnicode(false)
                    .HasComment("회사 아이디");

                entity.Property(e => e.department_idx).HasComment("부서 아이디");

                entity.Property(e => e.edit_date).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.idx).ValueGeneratedOnAdd();

                entity.Property(e => e.language).IsUnicode(false);

                entity.Property(e => e.main_bg_color)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('red')");

                entity.Property(e => e.manager_yn).IsUnicode(false);

                entity.Property(e => e.photo_profile).IsUnicode(false);

                entity.Property(e => e.use_yn)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.user_auth)
                    .IsUnicode(false)
                    .HasComment("사용자 권한");

                entity.Property(e => e.user_email).IsUnicode(false);

                entity.Property(e => e.user_name)
                    .IsUnicode(false)
                    .HasComment("사용자 명");

                entity.Property(e => e.user_password).IsUnicode(false);

                entity.Property(e => e.user_tel).IsUnicode(false);

                entity.Property(e => e.write_date).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.writer).IsUnicode(false);

                entity.HasOne(d => d.company_idxNavigation)
                    .WithMany(p => p.user)
                    .HasForeignKey(d => d.company_idx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_company");

                entity.HasOne(d => d.department_idxNavigation)
                    .WithMany(p => p.user)
                    .HasForeignKey(d => d.department_idx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_department");
            });

            modelBuilder.Entity<work_list>(entity =>
            {
                entity.Property(e => e.company_id).IsUnicode(false);

                entity.Property(e => e.content).HasComment("비고");

                entity.Property(e => e.department_id).IsUnicode(false);

                entity.Property(e => e.edit_date).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.gubun_code).HasComment("작업시간");

                entity.Property(e => e.gubun_type)
                    .IsUnicode(false)
                    .HasComment("프로젝트 코드");

                entity.Property(e => e.open_it)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Y')");

                entity.Property(e => e.project_idx).HasComment("프로젝트 고유코드");

                entity.Property(e => e.state)
                    .HasDefaultValueSql("((1))")
                    .HasComment("작업 상태");

                entity.Property(e => e.title).IsUnicode(false);

                entity.Property(e => e.use_yn)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Y')")
                    .HasComment("업무 분류");

                entity.Property(e => e.user_id).IsUnicode(false);

                entity.Property(e => e.who)
                    .IsUnicode(false)
                    .HasComment("참여인력");

                entity.Property(e => e.who_list).IsUnicode(false);

                entity.HasOne(d => d.indexNavigation)
                    .WithMany(p => p.work_list)
                    .HasForeignKey(d => d.index)
                    .HasConstraintName("FK_work_list_code_index");

                entity.HasOne(d => d.stateNavigation)
                    .WithMany(p => p.work_list)
                    .HasForeignKey(d => d.state)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_work_list_code_project_state");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
