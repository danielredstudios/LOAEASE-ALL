/*
 Navicat Premium Dump SQL

 Source Server         : localhost_3306
 Source Server Type    : MySQL
 Source Server Version : 100432 (10.4.32-MariaDB)
 Source Host           : localhost:3306
 Source Schema         : loa_ease_queuing_experiemental

 Target Server Type    : MySQL
 Target Server Version : 100432 (10.4.32-MariaDB)
 File Encoding         : 65001

 Date: 28/10/2025 09:43:44
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for admins
-- ----------------------------
DROP TABLE IF EXISTS `admins`;
CREATE TABLE `admins`  (
  `admin_id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `password_hash` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `full_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL DEFAULT 1,
  `is_locked` tinyint(1) NOT NULL DEFAULT 0,
  `lockout_until` datetime NULL DEFAULT NULL,
  `failed_login_attempts` int NOT NULL DEFAULT 0,
  `last_login` datetime NULL DEFAULT NULL,
  `last_login_ip` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`admin_id`) USING BTREE,
  UNIQUE INDEX `username`(`username` ASC) USING BTREE,
  INDEX `idx_username`(`username` ASC) USING BTREE,
  INDEX `idx_is_active`(`is_active` ASC) USING BTREE,
  INDEX `idx_is_locked`(`is_locked` ASC) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 9 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for cashiers
-- ----------------------------
DROP TABLE IF EXISTS `cashiers`;
CREATE TABLE `cashiers`  (
  `cashier_id` int NOT NULL AUTO_INCREMENT,
  `counter_id` int NULL DEFAULT NULL,
  `username` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `password_hash` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `role` enum('admin','cashier') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT 'cashier',
  `full_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL DEFAULT 1,
  `is_locked` tinyint(1) NOT NULL DEFAULT 0,
  `failed_login_attempts` int NOT NULL DEFAULT 0,
  `last_login` datetime NULL DEFAULT NULL,
  `last_login_ip` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE CURRENT_TIMESTAMP,
  `lockout_until` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`cashier_id`) USING BTREE,
  UNIQUE INDEX `username`(`username` ASC) USING BTREE,
  INDEX `counter_id`(`counter_id` ASC) USING BTREE,
  INDEX `idx_is_active`(`is_active` ASC) USING BTREE,
  INDEX `idx_is_locked`(`is_locked` ASC) USING BTREE,
  CONSTRAINT `cashiers_ibfk_1` FOREIGN KEY (`counter_id`) REFERENCES `counters` (`counter_id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 10 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for counter_schedules
-- ----------------------------
DROP TABLE IF EXISTS `counter_schedules`;
CREATE TABLE `counter_schedules`  (
  `schedule_id` int NOT NULL AUTO_INCREMENT,
  `counter_id` int NOT NULL,
  `is_open` tinyint(1) NOT NULL DEFAULT 1,
  `status` enum('open','break') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT 'open',
  `start_time` time NULL DEFAULT '08:00:00',
  `end_time` time NULL DEFAULT '17:00:00',
  PRIMARY KEY (`schedule_id`) USING BTREE,
  UNIQUE INDEX `counter_id`(`counter_id` ASC) USING BTREE,
  CONSTRAINT `counter_schedules_ibfk_1` FOREIGN KEY (`counter_id`) REFERENCES `counters` (`counter_id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for counters
-- ----------------------------
DROP TABLE IF EXISTS `counters`;
CREATE TABLE `counters`  (
  `counter_id` int NOT NULL AUTO_INCREMENT,
  `counter_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  PRIMARY KEY (`counter_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 14 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for guardians
-- ----------------------------
DROP TABLE IF EXISTS `guardians`;
CREATE TABLE `guardians`  (
  `guardian_id` int NOT NULL AUTO_INCREMENT,
  `full_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `phone_number` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`guardian_id`) USING BTREE,
  UNIQUE INDEX `email`(`email` ASC) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for login_attempts
-- ----------------------------
DROP TABLE IF EXISTS `login_attempts`;
CREATE TABLE `login_attempts`  (
  `attempt_id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `user_type` enum('admin','cashier','student','guardian','unknown') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT 'unknown',
  `user_id` int NULL DEFAULT NULL COMMENT 'ID from respective table (admin_id, cashier_id, user_id)',
  `success` tinyint(1) NOT NULL,
  `attempt_time` datetime NOT NULL,
  `ip_address` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `user_agent` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `notes` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`attempt_id`) USING BTREE,
  INDEX `idx_username`(`username` ASC) USING BTREE,
  INDEX `idx_user_type`(`user_type` ASC) USING BTREE,
  INDEX `idx_attempt_time`(`attempt_time` ASC) USING BTREE,
  INDEX `idx_success`(`success` ASC) USING BTREE,
  INDEX `idx_ip_address`(`ip_address` ASC) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 124 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Table structure for password_reset_token
-- ----------------------------
DROP TABLE IF EXISTS `password_reset_token`;
CREATE TABLE `password_reset_token`  (
  `token_id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `user_type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `token` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `expires_at` datetime NOT NULL,
  `is_used` tinyint(1) NOT NULL DEFAULT 0,
  `used_at` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`token_id`) USING BTREE,
  INDEX `token`(`token` ASC) USING BTREE,
  INDEX `email`(`email` ASC) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 4 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for queues
-- ----------------------------
DROP TABLE IF EXISTS `queues`;
CREATE TABLE `queues`  (
  `queue_id` int NOT NULL AUTO_INCREMENT,
  `student_id` int NULL DEFAULT NULL,
  `visitor_id` int NULL DEFAULT NULL,
  `counter_id` int NOT NULL,
  `queue_number` varchar(20) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `purpose` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `schedule_datetime` datetime NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `called_at` timestamp NULL DEFAULT NULL,
  `status` enum('waiting','serving','completed','cancelled','no-show','scheduled','expired') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT 'waiting',
  `is_priority` tinyint(1) NOT NULL DEFAULT 0,
  PRIMARY KEY (`queue_id`) USING BTREE,
  INDEX `student_id`(`student_id` ASC) USING BTREE,
  INDEX `counter_id`(`counter_id` ASC) USING BTREE,
  INDEX `queues_ibfk_3`(`visitor_id` ASC) USING BTREE,
  CONSTRAINT `queues_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `queues_ibfk_2` FOREIGN KEY (`counter_id`) REFERENCES `counters` (`counter_id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `queues_ibfk_3` FOREIGN KEY (`visitor_id`) REFERENCES `visitors` (`visitor_id`) ON DELETE SET NULL ON UPDATE CASCADE,
  CONSTRAINT `chk_student_or_visitor` CHECK (`student_id` is not null or `visitor_id` is not null)
) ENGINE = InnoDB AUTO_INCREMENT = 177 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for security_audit_log
-- ----------------------------
DROP TABLE IF EXISTS `security_audit_log`;
CREATE TABLE `security_audit_log`  (
  `log_id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `user_type` enum('admin','cashier','student','guardian','system') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `action` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT 'login, logout, password_change, account_locked, etc.',
  `description` text CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL,
  `ip_address` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `user_agent` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `severity` enum('info','warning','error','critical') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT 'info',
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`log_id`) USING BTREE,
  INDEX `idx_username`(`username` ASC) USING BTREE,
  INDEX `idx_action`(`action` ASC) USING BTREE,
  INDEX `idx_severity`(`severity` ASC) USING BTREE,
  INDEX `idx_created_at`(`created_at` ASC) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Table structure for settings
-- ----------------------------
DROP TABLE IF EXISTS `settings`;
CREATE TABLE `settings`  (
  `setting_key` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `setting_value` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`setting_key`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for student_guardian_map
-- ----------------------------
DROP TABLE IF EXISTS `student_guardian_map`;
CREATE TABLE `student_guardian_map`  (
  `map_id` int NOT NULL AUTO_INCREMENT,
  `student_id` int NOT NULL,
  `guardian_id` int NOT NULL,
  `relationship` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `is_active` tinyint(1) NOT NULL DEFAULT 1,
  PRIMARY KEY (`map_id`) USING BTREE,
  INDEX `student_id`(`student_id` ASC) USING BTREE,
  INDEX `guardian_id`(`guardian_id` ASC) USING BTREE,
  CONSTRAINT `student_guardian_map_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `student_guardian_map_ibfk_2` FOREIGN KEY (`guardian_id`) REFERENCES `guardians` (`guardian_id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for students
-- ----------------------------
DROP TABLE IF EXISTS `students`;
CREATE TABLE `students`  (
  `student_id` int NOT NULL AUTO_INCREMENT,
  `student_number` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `last_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `first_name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `middle_initial` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `course` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `year_level` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `visitor_id` int NULL DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`student_id`) USING BTREE,
  UNIQUE INDEX `student_number`(`student_number` ASC) USING BTREE,
  UNIQUE INDEX `email`(`email` ASC) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 58 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for user_lockouts
-- ----------------------------
DROP TABLE IF EXISTS `user_lockouts`;
CREATE TABLE `user_lockouts`  (
  `lockout_id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `user_type` enum('admin','cashier','student','guardian','unknown') CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL DEFAULT 'unknown',
  `user_id` int NULL DEFAULT NULL COMMENT 'ID from respective table',
  `failed_attempts` int NOT NULL DEFAULT 0,
  `lockout_until` datetime NULL DEFAULT NULL,
  `lockout_reason` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT 'Multiple failed login attempts',
  `last_attempt` datetime NOT NULL,
  `is_active` tinyint(1) NOT NULL DEFAULT 1,
  `ip_address` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`lockout_id`) USING BTREE,
  INDEX `idx_username`(`username` ASC) USING BTREE,
  INDEX `idx_user_type`(`user_type` ASC) USING BTREE,
  INDEX `idx_lockout_until`(`lockout_until` ASC) USING BTREE,
  INDEX `idx_is_active`(`is_active` ASC) USING BTREE,
  INDEX `idx_created_at`(`created_at` ASC) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 6 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users`  (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `student_id` int NULL DEFAULT NULL,
  `guardian_id` int NULL DEFAULT NULL,
  `username` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `password_hash` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `last_login` timestamp NULL DEFAULT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`user_id`) USING BTREE,
  UNIQUE INDEX `username`(`username` ASC) USING BTREE,
  UNIQUE INDEX `student_id`(`student_id` ASC) USING BTREE,
  UNIQUE INDEX `guardian_id`(`guardian_id` ASC) USING BTREE,
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`student_id`) REFERENCES `students` (`student_id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `users_ibfk_2` FOREIGN KEY (`guardian_id`) REFERENCES `guardians` (`guardian_id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 34 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for visitors
-- ----------------------------
DROP TABLE IF EXISTS `visitors`;
CREATE TABLE `visitors`  (
  `visitor_id` int NOT NULL AUTO_INCREMENT,
  `full_name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`visitor_id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Procedure structure for sp_check_active_lockout
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_check_active_lockout`;
delimiter ;;
CREATE PROCEDURE `sp_check_active_lockout`(IN p_username VARCHAR(100))
BEGIN
  SELECT 
    lockout_id, 
    username, 
    user_type, 
    failed_attempts, 
    lockout_until, 
    is_active,
    TIMESTAMPDIFF(SECOND, NOW(), lockout_until) AS seconds_remaining
  FROM user_lockouts
  WHERE (p_username = '' OR username = p_username)
    AND is_active = 1 
    AND lockout_until > NOW()
  ORDER BY lockout_until DESC 
  LIMIT 1;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for sp_clear_lockout
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_clear_lockout`;
delimiter ;;
CREATE PROCEDURE `sp_clear_lockout`(IN p_username VARCHAR(100))
BEGIN
  UPDATE user_lockouts SET is_active = 0 WHERE username = p_username AND is_active = 1;
  UPDATE admins SET is_locked = 0, failed_login_attempts = 0 WHERE username = p_username;
  UPDATE cashiers SET is_locked = 0, failed_login_attempts = 0 WHERE username = p_username;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for sp_create_lockout
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_create_lockout`;
delimiter ;;
CREATE PROCEDURE `sp_create_lockout`(IN p_username VARCHAR(100), 
  IN p_user_type VARCHAR(20), 
  IN p_user_id INT,
  IN p_failed_attempts INT, 
  IN p_lockout_minutes INT, 
  IN p_ip_address VARCHAR(45))
BEGIN
  UPDATE user_lockouts 
  SET is_active = 0 
  WHERE username = p_username AND is_active = 1;
  
  INSERT INTO user_lockouts (username, user_type, user_id, failed_attempts,
                             lockout_until, last_attempt, is_active, ip_address)
  VALUES (p_username, p_user_type, p_user_id, p_failed_attempts,
          DATE_ADD(NOW(), INTERVAL p_lockout_minutes MINUTE), NOW(), 1, p_ip_address);
  
  IF p_user_type = 'admin' THEN
    UPDATE admins SET is_locked = 1 WHERE username = p_username;
  ELSEIF p_user_type = 'cashier' THEN
    UPDATE cashiers SET is_locked = 1 WHERE username = p_username;
  END IF;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for sp_get_lockout_duration
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_get_lockout_duration`;
delimiter ;;
CREATE PROCEDURE `sp_get_lockout_duration`(IN p_username VARCHAR(100))
BEGIN
  DECLARE lockout_count INT;
  DECLARE duration INT;
  
  SELECT COUNT(*) INTO lockout_count FROM user_lockouts
  WHERE username = p_username AND lockout_until IS NOT NULL
  AND created_at > DATE_SUB(NOW(), INTERVAL 24 HOUR);
  
  CASE 
    WHEN lockout_count = 0 THEN SET duration = 5;
    WHEN lockout_count = 1 THEN SET duration = 15;
    WHEN lockout_count = 2 THEN SET duration = 30;
    ELSE SET duration = 60;
  END CASE;
  
  SELECT duration AS lockout_duration_minutes;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for sp_get_user_by_username
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_get_user_by_username`;
delimiter ;;
CREATE PROCEDURE `sp_get_user_by_username`(IN p_username VARCHAR(100))
BEGIN
  SELECT 
    'admin' AS role, 
    admin_id AS id, 
    admin_id, 
    NULL AS cashier_id, 
    NULL AS counter_id,
    username, 
    password_hash, 
    full_name, 
    email, 
    is_active, 
    is_locked, 
    failed_login_attempts, 
    last_login
  FROM admins 
  WHERE username = p_username
  
  UNION ALL
  
  SELECT 
    role, 
    cashier_id AS id, 
    NULL AS admin_id, 
    cashier_id, 
    counter_id,
    username, 
    password_hash, 
    full_name, 
    email, 
    is_active, 
    is_locked, 
    failed_login_attempts, 
    last_login
  FROM cashiers 
  WHERE username = p_username
  
  LIMIT 1;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for sp_record_login_attempt
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_record_login_attempt`;
delimiter ;;
CREATE PROCEDURE `sp_record_login_attempt`(IN p_username VARCHAR(100), 
  IN p_user_type VARCHAR(20), 
  IN p_user_id INT,
  IN p_success TINYINT(1), 
  IN p_ip_address VARCHAR(45), 
  IN p_user_agent VARCHAR(255), 
  IN p_notes TEXT)
BEGIN
  INSERT INTO login_attempts (username, user_type, user_id, success, attempt_time, 
                              ip_address, user_agent, notes)
  VALUES (p_username, p_user_type, p_user_id, p_success, NOW(), 
          p_ip_address, p_user_agent, p_notes);
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for sp_set_user_lock_status
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_set_user_lock_status`;
delimiter ;;
CREATE PROCEDURE `sp_set_user_lock_status`(IN p_username VARCHAR(100), 
  IN p_user_type VARCHAR(20), 
  IN p_is_locked TINYINT(1))
BEGIN
  IF p_user_type = 'admin' THEN
    UPDATE admins SET is_locked = p_is_locked WHERE username = p_username;
  ELSEIF p_user_type = 'cashier' THEN
    UPDATE cashiers SET is_locked = p_is_locked WHERE username = p_username;
  END IF;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for sp_update_failed_attempts
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_update_failed_attempts`;
delimiter ;;
CREATE PROCEDURE `sp_update_failed_attempts`(IN p_username VARCHAR(100), 
  IN p_user_type VARCHAR(20), 
  IN p_attempts INT)
BEGIN
  IF p_user_type = 'admin' THEN
    UPDATE admins SET failed_login_attempts = p_attempts WHERE username = p_username;
  ELSEIF p_user_type = 'cashier' THEN
    UPDATE cashiers SET failed_login_attempts = p_attempts WHERE username = p_username;
  END IF;
END
;;
delimiter ;

-- ----------------------------
-- Procedure structure for sp_update_last_login
-- ----------------------------
DROP PROCEDURE IF EXISTS `sp_update_last_login`;
delimiter ;;
CREATE PROCEDURE `sp_update_last_login`(IN p_username VARCHAR(100), 
  IN p_user_type VARCHAR(20), 
  IN p_ip_address VARCHAR(45))
BEGIN
  IF p_user_type = 'admin' THEN
    UPDATE admins 
    SET last_login = NOW(), last_login_ip = p_ip_address, failed_login_attempts = 0 
    WHERE username = p_username;
  ELSEIF p_user_type = 'cashier' THEN
    UPDATE cashiers 
    SET last_login = NOW(), last_login_ip = p_ip_address, failed_login_attempts = 0 
    WHERE username = p_username;
  END IF;
END
;;
delimiter ;

SET FOREIGN_KEY_CHECKS = 1;
