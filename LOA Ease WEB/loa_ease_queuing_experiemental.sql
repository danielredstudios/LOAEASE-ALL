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

 Date: 28/10/2025 18:01:06
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
-- Records of admins
-- ----------------------------
INSERT INTO `admins` VALUES (2, 'admin', '$2b$10$w6o6SmCBRceoZulvbDsvQOEM.aYRQVytcAjnSfKX58LLJnD5nNThK', 'Daniel Red - Admin', NULL, 1, 0, NULL, 0, '2025-10-28 12:23:50', '192.168.56.1', '2025-10-25 18:17:32', '2025-10-28 12:23:50');
INSERT INTO `admins` VALUES (4, 'admin2', '$2b$10$RLayhpi9StqNYPuavPLw2u4jB718Nv3SAz9JPk4CprmZtFirv6UMW', 'Gavin Penaranda - Admin', NULL, 1, 1, NULL, 3, '2025-10-27 09:55:37', '172.20.48.1', '2025-10-26 20:16:53', '2025-10-27 18:08:31');
INSERT INTO `admins` VALUES (5, 'admin3', '$2b$10$EQJPAaMHRfcGSWhOM.05hOKKJSJOn50ASKgXXgHnVseW3gFKYb3Ji', 'Jhiro DelaCruz - Admin', NULL, 1, 0, NULL, 0, NULL, NULL, '2025-10-27 18:09:32', '2025-10-27 18:09:56');
INSERT INTO `admins` VALUES (8, 'admin4', '$2b$10$08Cf4scC82wImLuVsf5EmeQfdZyFeDYWL0QpiYezDm5XPPOinYbRG', 'Sean Yzer', NULL, 1, 0, NULL, 0, NULL, NULL, '2025-10-27 18:17:53', '2025-10-27 18:17:53');

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
-- Records of cashiers
-- ----------------------------
INSERT INTO `cashiers` VALUES (1, 1, 'cashier1', '$2y$10$sDWBtkmB.FPx/1490owM8.NSX9C.IVynpFyKPI67wLyyysnlVBXOW', 'cashier', 'Cashier 1 - Daniel Red', NULL, 1, 0, 0, '2025-10-28 12:24:09', '192.168.56.1', '2025-10-25 18:22:37', '2025-10-28 12:24:09', NULL);
INSERT INTO `cashiers` VALUES (2, 2, 'cashier2', '$2y$10$sDWBtkmB.FPx/1490owM8.NSX9C.IVynpFyKPI67wLyyysnlVBXOW', 'cashier', 'Cashier 2 -  GAVIN PEÑARANDA', NULL, 1, 0, 0, '2025-10-27 18:54:50', '192.168.56.1', '2025-10-25 18:22:37', '2025-10-27 18:54:50', NULL);
INSERT INTO `cashiers` VALUES (3, 3, 'cashier3', '$2y$10$sDWBtkmB.FPx/1490owM8.NSX9C.IVynpFyKPI67wLyyysnlVBXOW', 'cashier', 'Cashier 3 - JEANROMUALD DELA CRUZ', NULL, 1, 0, 0, NULL, NULL, '2025-10-25 18:22:37', '2025-10-25 18:22:37', NULL);
INSERT INTO `cashiers` VALUES (4, 4, 'cashier4', '$2b$10$4pdDM4mGE.rfGQ5MchOtquPVvrv1UQ5p9JG0nJyyhD0t6MKRN/AGm', 'cashier', 'Cashier 4 - Gavin Penaranda', NULL, 1, 0, 0, '2025-10-27 12:19:57', '172.20.48.1', '2025-10-25 18:22:37', '2025-10-27 12:19:57', NULL);

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
-- Records of counter_schedules
-- ----------------------------
INSERT INTO `counter_schedules` VALUES (1, 1, 0, 'open', '08:00:00', '22:19:06');
INSERT INTO `counter_schedules` VALUES (2, 2, 0, 'open', '08:00:00', '17:00:00');
INSERT INTO `counter_schedules` VALUES (3, 3, 0, 'open', '08:00:00', '17:00:00');
INSERT INTO `counter_schedules` VALUES (4, 4, 0, 'open', '08:00:00', '17:00:00');

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
-- Records of counters
-- ----------------------------
INSERT INTO `counters` VALUES (1, 'Cashier 1');
INSERT INTO `counters` VALUES (2, 'Cashier 2');
INSERT INTO `counters` VALUES (3, 'Cashier 3');
INSERT INTO `counters` VALUES (4, 'Cashier 4');
INSERT INTO `counters` VALUES (13, 'Cashier 5');

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
-- Records of guardians
-- ----------------------------

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
) ENGINE = InnoDB AUTO_INCREMENT = 128 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of login_attempts
-- ----------------------------
INSERT INTO `login_attempts` VALUES (1, 'Admin', 'unknown', NULL, 0, '2025-10-25 18:35:20', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 1 of 3', '2025-10-25 18:35:20');
INSERT INTO `login_attempts` VALUES (2, 'Admin', 'admin', 2, 0, '2025-10-25 18:40:30', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 1 of 3', '2025-10-25 18:40:30');
INSERT INTO `login_attempts` VALUES (3, 'admin', 'admin', 2, 0, '2025-10-25 18:40:37', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 2 of 3', '2025-10-25 18:40:37');
INSERT INTO `login_attempts` VALUES (4, 'admin', 'admin', 2, 1, '2025-10-25 18:41:33', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-25 18:41:33');
INSERT INTO `login_attempts` VALUES (5, 'admin', 'admin', 2, 0, '2025-10-25 18:41:51', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 1 of 3', '2025-10-25 18:41:51');
INSERT INTO `login_attempts` VALUES (6, 'admin', 'admin', 2, 1, '2025-10-25 19:31:06', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-25 19:31:06');
INSERT INTO `login_attempts` VALUES (7, 'admin', 'admin', 2, 1, '2025-10-25 19:31:40', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-25 19:31:40');
INSERT INTO `login_attempts` VALUES (8, 'admin', 'admin', 2, 1, '2025-10-25 19:35:41', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-25 19:35:41');
INSERT INTO `login_attempts` VALUES (9, 'admin', 'admin', 2, 1, '2025-10-25 19:42:30', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-25 19:42:30');
INSERT INTO `login_attempts` VALUES (10, 'admin', 'admin', 2, 1, '2025-10-25 19:43:44', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-25 19:43:44');
INSERT INTO `login_attempts` VALUES (11, 'admin', 'admin', 2, 1, '2025-10-26 16:56:44', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 16:56:44');
INSERT INTO `login_attempts` VALUES (12, 'admin', 'admin', 2, 1, '2025-10-26 17:09:41', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 17:09:41');
INSERT INTO `login_attempts` VALUES (13, 'admin', 'admin', 2, 1, '2025-10-26 17:16:15', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 17:16:15');
INSERT INTO `login_attempts` VALUES (14, 'admin', 'admin', 2, 1, '2025-10-26 18:03:09', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 18:03:09');
INSERT INTO `login_attempts` VALUES (15, 'admin', 'admin', 2, 0, '2025-10-26 18:07:47', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 1 of 3', '2025-10-26 18:07:47');
INSERT INTO `login_attempts` VALUES (16, 'admin', 'admin', 2, 1, '2025-10-26 18:07:53', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 18:07:53');
INSERT INTO `login_attempts` VALUES (17, 'cashier1', 'cashier', 1, 1, '2025-10-26 18:08:23', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 18:08:23');
INSERT INTO `login_attempts` VALUES (18, 'admin', 'admin', 2, 1, '2025-10-26 18:08:28', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 18:08:28');
INSERT INTO `login_attempts` VALUES (19, 'admin', 'admin', 2, 1, '2025-10-26 18:26:24', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 18:26:24');
INSERT INTO `login_attempts` VALUES (20, 'admin', 'admin', 2, 1, '2025-10-26 18:41:40', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 18:41:40');
INSERT INTO `login_attempts` VALUES (21, 'admin', 'admin', 2, 1, '2025-10-26 19:07:11', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 19:07:11');
INSERT INTO `login_attempts` VALUES (22, 'admin', 'admin', 2, 1, '2025-10-26 19:14:07', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 19:14:07');
INSERT INTO `login_attempts` VALUES (23, 'admin', 'admin', 2, 0, '2025-10-26 19:18:29', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 1 of 3', '2025-10-26 19:18:29');
INSERT INTO `login_attempts` VALUES (24, 'admin', 'admin', 2, 0, '2025-10-26 19:18:38', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 2 of 3', '2025-10-26 19:18:38');
INSERT INTO `login_attempts` VALUES (25, 'admin', 'admin', 2, 1, '2025-10-26 19:18:44', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 19:18:44');
INSERT INTO `login_attempts` VALUES (26, 'admin2', 'admin', 3, 1, '2025-10-26 19:19:49', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 19:19:49');
INSERT INTO `login_attempts` VALUES (27, 'admin', 'admin', 2, 1, '2025-10-26 19:29:22', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 19:29:22');
INSERT INTO `login_attempts` VALUES (28, 'admin', 'admin', 2, 1, '2025-10-26 19:30:07', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 19:30:07');
INSERT INTO `login_attempts` VALUES (29, 'admin', 'admin', 2, 1, '2025-10-26 19:35:43', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 19:35:43');
INSERT INTO `login_attempts` VALUES (30, 'admin', 'admin', 2, 1, '2025-10-26 20:05:29', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 20:05:29');
INSERT INTO `login_attempts` VALUES (31, 'admin', 'admin', 2, 1, '2025-10-26 20:16:25', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 20:16:25');
INSERT INTO `login_attempts` VALUES (32, 'admin', 'admin', 2, 1, '2025-10-26 20:34:35', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 20:34:35');
INSERT INTO `login_attempts` VALUES (33, 'admin', 'admin', 2, 0, '2025-10-26 20:43:11', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 1 of 3', '2025-10-26 20:43:11');
INSERT INTO `login_attempts` VALUES (34, 'admin', 'admin', 2, 1, '2025-10-26 20:43:16', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 20:43:16');
INSERT INTO `login_attempts` VALUES (35, 'admin', 'admin', 2, 1, '2025-10-26 20:44:13', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 20:44:13');
INSERT INTO `login_attempts` VALUES (36, 'admin', 'admin', 2, 1, '2025-10-26 20:48:34', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 20:48:34');
INSERT INTO `login_attempts` VALUES (37, 'admin', 'admin', 2, 1, '2025-10-26 20:54:44', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 20:54:44');
INSERT INTO `login_attempts` VALUES (38, 'admin', 'admin', 2, 1, '2025-10-26 21:01:20', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 21:01:20');
INSERT INTO `login_attempts` VALUES (39, 'admin', 'admin', 2, 1, '2025-10-26 21:06:21', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 21:06:21');
INSERT INTO `login_attempts` VALUES (40, 'admin', 'admin', 2, 1, '2025-10-26 21:06:49', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 21:06:49');
INSERT INTO `login_attempts` VALUES (41, 'admin', 'admin', 2, 1, '2025-10-26 21:20:22', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 21:20:22');
INSERT INTO `login_attempts` VALUES (42, 'admin', 'admin', 2, 1, '2025-10-26 21:30:02', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 21:30:02');
INSERT INTO `login_attempts` VALUES (43, 'admin', 'admin', 2, 1, '2025-10-26 21:37:49', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 21:37:49');
INSERT INTO `login_attempts` VALUES (44, 'admin', 'admin', 2, 1, '2025-10-26 21:51:16', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 21:51:16');
INSERT INTO `login_attempts` VALUES (45, 'admin2', 'admin', 4, 1, '2025-10-26 21:52:27', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 21:52:27');
INSERT INTO `login_attempts` VALUES (46, 'admin', 'admin', 2, 0, '2025-10-26 21:54:20', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 1 of 3', '2025-10-26 21:54:20');
INSERT INTO `login_attempts` VALUES (47, 'admin', 'admin', 2, 0, '2025-10-26 21:55:14', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 2 of 3', '2025-10-26 21:55:14');
INSERT INTO `login_attempts` VALUES (48, 'admin', 'admin', 2, 0, '2025-10-26 21:55:23', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 3 of 3', '2025-10-26 21:55:23');
INSERT INTO `login_attempts` VALUES (49, 'admin', 'admin', 2, 0, '2025-10-26 21:55:23', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Account locked for 5 minutes due to 3 failed attempts', '2025-10-26 21:55:23');
INSERT INTO `login_attempts` VALUES (50, 'admin', 'admin', 2, 0, '2025-10-26 22:08:49', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Login attempt on inactive account', '2025-10-26 22:08:49');
INSERT INTO `login_attempts` VALUES (51, 'admin1', 'unknown', NULL, 0, '2025-10-26 22:08:58', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Login attempt with non-existent username', '2025-10-26 22:08:58');
INSERT INTO `login_attempts` VALUES (52, 'admin1', 'unknown', NULL, 0, '2025-10-26 22:09:05', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Login attempt with non-existent username', '2025-10-26 22:09:05');
INSERT INTO `login_attempts` VALUES (53, 'cashier1', 'cashier', 1, 1, '2025-10-26 22:09:16', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 22:09:16');
INSERT INTO `login_attempts` VALUES (54, 'admin', 'admin', 2, 0, '2025-10-26 22:09:27', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Login attempt on inactive account', '2025-10-26 22:09:27');
INSERT INTO `login_attempts` VALUES (55, 'admin1', 'unknown', NULL, 0, '2025-10-26 22:09:34', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Login attempt with non-existent username', '2025-10-26 22:09:34');
INSERT INTO `login_attempts` VALUES (56, 'admin1', 'unknown', NULL, 0, '2025-10-26 22:09:42', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Login attempt with non-existent username', '2025-10-26 22:09:42');
INSERT INTO `login_attempts` VALUES (57, 'admin', 'admin', 2, 0, '2025-10-26 22:10:11', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Login attempt on inactive account', '2025-10-26 22:10:11');
INSERT INTO `login_attempts` VALUES (58, 'admin1', 'unknown', NULL, 0, '2025-10-26 22:10:20', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Login attempt with non-existent username', '2025-10-26 22:10:20');
INSERT INTO `login_attempts` VALUES (59, 'admin', 'admin', 2, 1, '2025-10-26 22:10:50', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 22:10:50');
INSERT INTO `login_attempts` VALUES (60, 'admin2', 'admin', 4, 0, '2025-10-26 22:11:11', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Login attempt on inactive account', '2025-10-26 22:11:11');
INSERT INTO `login_attempts` VALUES (61, 'cashier1', 'cashier', 1, 1, '2025-10-26 22:11:26', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 22:11:26');
INSERT INTO `login_attempts` VALUES (62, 'cashier1', 'cashier', 1, 0, '2025-10-26 22:11:34', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 1 of 3 (Password Incorrect)', '2025-10-26 22:11:34');
INSERT INTO `login_attempts` VALUES (63, 'cashier1', 'cashier', 1, 0, '2025-10-26 22:11:38', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 2 of 3 (Password Incorrect)', '2025-10-26 22:11:38');
INSERT INTO `login_attempts` VALUES (64, 'cashier1', 'cashier', 1, 0, '2025-10-26 22:11:40', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 3 of 3 (Password Incorrect)', '2025-10-26 22:11:40');
INSERT INTO `login_attempts` VALUES (65, 'cashier1', 'cashier', 1, 0, '2025-10-26 22:11:40', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Account locked for 5 minutes due to 3 failed attempts', '2025-10-26 22:11:40');
INSERT INTO `login_attempts` VALUES (66, 'admin', 'admin', 2, 1, '2025-10-26 22:12:06', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 22:12:06');
INSERT INTO `login_attempts` VALUES (67, 'admin', 'admin', 2, 0, '2025-10-26 22:12:15', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 1 of 3 (Password Incorrect)', '2025-10-26 22:12:15');
INSERT INTO `login_attempts` VALUES (68, 'admin', 'admin', 2, 0, '2025-10-26 22:12:17', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 2 of 3 (Password Incorrect)', '2025-10-26 22:12:17');
INSERT INTO `login_attempts` VALUES (69, 'admin', 'admin', 2, 0, '2025-10-26 22:12:19', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 3 of 3 (Password Incorrect)', '2025-10-26 22:12:19');
INSERT INTO `login_attempts` VALUES (70, 'admin', 'admin', 2, 0, '2025-10-26 22:12:19', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Account locked for 5 minutes due to 3 failed attempts', '2025-10-26 22:12:19');
INSERT INTO `login_attempts` VALUES (71, 'admin2', 'admin', 4, 1, '2025-10-26 22:13:37', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 22:13:37');
INSERT INTO `login_attempts` VALUES (72, 'admin', 'admin', 2, 1, '2025-10-26 22:26:00', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 22:26:00');
INSERT INTO `login_attempts` VALUES (73, 'cashier1', 'cashier', 1, 0, '2025-10-26 22:26:18', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Login attempt on locked account', '2025-10-26 22:26:18');
INSERT INTO `login_attempts` VALUES (74, 'cashier1', 'cashier', 1, 0, '2025-10-26 22:26:23', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Login attempt on locked account', '2025-10-26 22:26:23');
INSERT INTO `login_attempts` VALUES (75, 'cashier1', 'cashier', 1, 0, '2025-10-26 22:26:26', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Login attempt on locked account', '2025-10-26 22:26:26');
INSERT INTO `login_attempts` VALUES (76, 'cashier1', 'cashier', 1, 0, '2025-10-26 22:26:37', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Login attempt on locked account', '2025-10-26 22:26:37');
INSERT INTO `login_attempts` VALUES (77, 'admin', 'admin', 2, 1, '2025-10-26 22:26:44', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-26 22:26:44');
INSERT INTO `login_attempts` VALUES (78, 'admin', 'admin', 2, 0, '2025-10-27 09:50:18', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 1 of 3 (Password Incorrect)', '2025-10-27 09:50:18');
INSERT INTO `login_attempts` VALUES (79, 'admin', 'admin', 2, 0, '2025-10-27 09:50:21', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 2 of 3 (Password Incorrect)', '2025-10-27 09:50:21');
INSERT INTO `login_attempts` VALUES (80, 'admin', 'admin', 2, 0, '2025-10-27 09:50:23', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 3 of 3 (Password Incorrect)', '2025-10-27 09:50:23');
INSERT INTO `login_attempts` VALUES (81, 'admin', 'admin', 2, 0, '2025-10-27 09:50:23', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Account locked for 15 minutes due to 3 failed attempts', '2025-10-27 09:50:23');
INSERT INTO `login_attempts` VALUES (82, 'admin2', 'admin', 4, 1, '2025-10-27 09:55:37', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 09:55:37');
INSERT INTO `login_attempts` VALUES (83, 'admin', 'admin', 2, 1, '2025-10-27 10:24:36', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 10:24:36');
INSERT INTO `login_attempts` VALUES (84, 'admin', 'admin', 2, 1, '2025-10-27 10:27:10', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 10:27:10');
INSERT INTO `login_attempts` VALUES (85, 'admin', 'admin', 2, 1, '2025-10-27 10:50:07', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 10:50:07');
INSERT INTO `login_attempts` VALUES (86, 'admin', 'admin', 2, 0, '2025-10-27 10:50:27', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 1 of 3 (Password Incorrect)', '2025-10-27 10:50:27');
INSERT INTO `login_attempts` VALUES (87, 'admin', 'admin', 2, 1, '2025-10-27 10:50:32', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 10:50:32');
INSERT INTO `login_attempts` VALUES (88, 'admin2', 'admin', 4, 0, '2025-10-27 10:50:57', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 1 of 3 (Password Incorrect)', '2025-10-27 10:50:57');
INSERT INTO `login_attempts` VALUES (89, 'admin2', 'admin', 4, 0, '2025-10-27 10:50:59', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 2 of 3 (Password Incorrect)', '2025-10-27 10:50:59');
INSERT INTO `login_attempts` VALUES (90, 'admin2', 'admin', 4, 0, '2025-10-27 10:51:02', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 3 of 3 (Password Incorrect)', '2025-10-27 10:51:02');
INSERT INTO `login_attempts` VALUES (91, 'admin2', 'admin', 4, 0, '2025-10-27 10:51:02', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Account locked for 5 minutes due to 3 failed attempts', '2025-10-27 10:51:02');
INSERT INTO `login_attempts` VALUES (92, 'admin', 'admin', 2, 1, '2025-10-27 10:51:27', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 10:51:27');
INSERT INTO `login_attempts` VALUES (93, 'admin', 'admin', 2, 1, '2025-10-27 11:03:57', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 11:03:57');
INSERT INTO `login_attempts` VALUES (94, 'admin', 'admin', 2, 0, '2025-10-27 11:10:06', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Failed attempt 1 of 3 (Password Incorrect)', '2025-10-27 11:10:06');
INSERT INTO `login_attempts` VALUES (95, 'admin', 'admin', 2, 1, '2025-10-27 11:10:11', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 11:10:11');
INSERT INTO `login_attempts` VALUES (96, 'admin', 'admin', 2, 1, '2025-10-27 11:15:22', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 11:15:22');
INSERT INTO `login_attempts` VALUES (97, 'admin', 'admin', 2, 1, '2025-10-27 11:16:58', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 11:16:58');
INSERT INTO `login_attempts` VALUES (98, 'admin', 'admin', 2, 1, '2025-10-27 11:25:40', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 11:25:40');
INSERT INTO `login_attempts` VALUES (99, 'admin', 'admin', 2, 1, '2025-10-27 11:31:12', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 11:31:12');
INSERT INTO `login_attempts` VALUES (100, 'admin', 'admin', 2, 1, '2025-10-27 11:37:13', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 11:37:13');
INSERT INTO `login_attempts` VALUES (101, 'admin', 'admin', 2, 1, '2025-10-27 11:42:56', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 11:42:56');
INSERT INTO `login_attempts` VALUES (102, 'admin', 'admin', 2, 1, '2025-10-27 11:43:48', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 11:43:48');
INSERT INTO `login_attempts` VALUES (103, 'admin', 'admin', 2, 1, '2025-10-27 11:55:46', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 11:55:46');
INSERT INTO `login_attempts` VALUES (104, 'cashier1', 'cashier', 1, 0, '2025-10-27 11:56:15', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Login attempt on inactive account', '2025-10-27 11:56:15');
INSERT INTO `login_attempts` VALUES (105, 'admin', 'admin', 2, 1, '2025-10-27 11:56:21', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 11:56:21');
INSERT INTO `login_attempts` VALUES (106, 'admin', 'admin', 2, 1, '2025-10-27 12:06:57', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 12:06:57');
INSERT INTO `login_attempts` VALUES (107, 'admin', 'admin', 2, 1, '2025-10-27 12:09:20', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 12:09:20');
INSERT INTO `login_attempts` VALUES (108, 'admin', 'admin', 2, 1, '2025-10-27 12:17:57', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 12:17:57');
INSERT INTO `login_attempts` VALUES (109, 'cashier4', 'cashier', 4, 1, '2025-10-27 12:19:57', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 12:19:57');
INSERT INTO `login_attempts` VALUES (110, 'admin', 'admin', 2, 1, '2025-10-27 12:20:05', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 12:20:05');
INSERT INTO `login_attempts` VALUES (111, 'admin', 'admin', 2, 1, '2025-10-27 12:25:35', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 12:25:35');
INSERT INTO `login_attempts` VALUES (112, 'admin', 'admin', 2, 1, '2025-10-27 12:29:10', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 12:29:10');
INSERT INTO `login_attempts` VALUES (113, 'admin', 'admin', 2, 1, '2025-10-27 12:38:10', '172.20.48.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 12:38:10');
INSERT INTO `login_attempts` VALUES (114, 'admin', 'admin', 2, 1, '2025-10-27 17:18:40', '192.168.56.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 17:18:40');
INSERT INTO `login_attempts` VALUES (115, 'admin', 'admin', 2, 1, '2025-10-27 18:03:32', '192.168.56.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 18:03:32');
INSERT INTO `login_attempts` VALUES (116, 'admin', 'admin', 2, 1, '2025-10-27 18:25:11', '192.168.56.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 18:25:11');
INSERT INTO `login_attempts` VALUES (117, 'admin', 'admin', 2, 1, '2025-10-27 18:30:55', '192.168.56.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 18:30:55');
INSERT INTO `login_attempts` VALUES (118, 'admin', 'admin', 2, 1, '2025-10-27 18:45:14', '192.168.56.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 18:45:14');
INSERT INTO `login_attempts` VALUES (119, 'admin', 'admin', 2, 1, '2025-10-27 18:49:45', '192.168.56.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 18:49:45');
INSERT INTO `login_attempts` VALUES (120, 'cashier1', 'cashier', 1, 0, '2025-10-27 18:53:59', '192.168.56.1', 'Microsoft Windows NT 10.0.26100.0', 'Login attempt on locked account', '2025-10-27 18:53:59');
INSERT INTO `login_attempts` VALUES (121, 'admin', 'admin', 2, 1, '2025-10-27 18:54:08', '192.168.56.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 18:54:08');
INSERT INTO `login_attempts` VALUES (122, 'cashier2', 'cashier', 2, 1, '2025-10-27 18:54:50', '192.168.56.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 18:54:50');
INSERT INTO `login_attempts` VALUES (123, 'admin', 'admin', 2, 1, '2025-10-27 18:55:23', '192.168.56.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-27 18:55:23');
INSERT INTO `login_attempts` VALUES (124, 'admin', 'admin', 2, 1, '2025-10-28 11:11:07', '192.168.56.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-28 11:11:07');
INSERT INTO `login_attempts` VALUES (125, 'cashier1', 'cashier', 1, 1, '2025-10-28 12:23:31', '192.168.56.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-28 12:23:31');
INSERT INTO `login_attempts` VALUES (126, 'admin', 'admin', 2, 1, '2025-10-28 12:23:50', '192.168.56.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-28 12:23:50');
INSERT INTO `login_attempts` VALUES (127, 'cashier1', 'cashier', 1, 1, '2025-10-28 12:24:09', '192.168.56.1', 'Microsoft Windows NT 10.0.26100.0', 'Successful login', '2025-10-28 12:24:09');

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
) ENGINE = InnoDB AUTO_INCREMENT = 17 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of password_reset_token
-- ----------------------------
INSERT INTO `password_reset_token` VALUES (5, 'yuan.rodriguez', 'student', 'C1949-23@itmlyceumalabang.onmicrosoft.com', '46071bcd0d54f8606f1091d8a7e0a7d699959553dc38088da5e3c2c44aa6bb6d98b2382313f0abdd9f530856a2dbf5c832fd', '2025-10-28 10:25:30', 0, NULL);
INSERT INTO `password_reset_token` VALUES (6, 'sean.atog', 'student', 'C1118-23@itmlyceumalabang.onmicrosoft.com', '41f690a6424ed97b3e3afa137767098421d7966c979cb175c2c4adba49b1f487a38a312350dd1048f6c92ea20b1c46528917', '2025-10-28 10:27:40', 0, NULL);
INSERT INTO `password_reset_token` VALUES (14, 'daniel.red', 'student', 'c1030-23@itmlyceumalabang.onmicrosoft.com', 'cd5face6f77ffb3b0f61e772a5de5d07e3754979f3274c70838fe287ddbdd98cdcd1cb46739a33978f63c2ac73f8c49f4004', '2025-10-28 11:28:51', 1, '2025-10-28 10:59:34');
INSERT INTO `password_reset_token` VALUES (15, 'daniel.red', 'student', 'c1030-23@itmlyceumalabang.onmicrosoft.com', '4717970c119993dbb0231eb64ad6832d8705f3c9f7983cd6d13e76fee73104b9feeede58ade93510bfea3cc55d49a9f691a1', '2025-10-28 11:29:55', 1, '2025-10-28 11:00:21');
INSERT INTO `password_reset_token` VALUES (16, 'daniel.red', 'student', 'c1030-23@itmlyceumalabang.onmicrosoft.com', 'ad5399fd8ffd5f8900dd2fd52b0ab2f7a6039f6d77c62d5bb10caa1c56efe30c8635ee287c807f2599defbc0c53f5efc36ab', '2025-10-28 12:07:41', 0, NULL);

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
) ENGINE = InnoDB AUTO_INCREMENT = 181 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of queues
-- ----------------------------
INSERT INTO `queues` VALUES (51, 21, NULL, 2, 'CCS-0926-001', 'Tuition Payment', '2025-09-26 08:00:00', '2025-09-26 08:45:19', '2025-09-26 08:51:07', 'completed', 0);
INSERT INTO `queues` VALUES (53, 21, NULL, 2, 'CCS-0926-002', 'Tuition Payment', '2025-09-26 08:30:00', '2025-09-26 08:50:24', '2025-09-26 08:51:14', 'completed', 0);
INSERT INTO `queues` VALUES (58, 21, NULL, 2, 'CCS-0926-009', 'Tuition Payment, Enrollment Concern, Promissory Note, Document Request, doc_req:Transcript of Records (TOR)', '2025-09-26 10:00:00', '2025-09-26 09:37:35', '2025-09-26 09:37:47', 'completed', 0);
INSERT INTO `queues` VALUES (68, 36, NULL, 2, 'CCS-0926-019', 'Tuition Payment, Enrollment Concern', '2025-09-26 11:00:00', '2025-09-26 10:15:09', '2025-09-26 10:17:02', 'completed', 0);
INSERT INTO `queues` VALUES (70, 38, NULL, 2, 'CCS-0926-021', 'Tuition Payment, Enrollment Concern', '2025-09-26 12:00:00', '2025-09-26 10:22:00', '2025-09-26 10:24:38', 'completed', 0);
INSERT INTO `queues` VALUES (71, 43, NULL, 2, 'CCS-0926-022', 'Tuition Payment', '2025-09-26 12:30:00', '2025-09-26 10:23:39', '2025-09-26 10:26:15', 'completed', 0);
INSERT INTO `queues` VALUES (99, 26, NULL, 2, 'CCS-0929-016', 'Tuition Payment', '2025-09-29 15:37:50', '2025-09-29 15:37:50', '2025-09-29 15:38:03', 'completed', 0);
INSERT INTO `queues` VALUES (100, 41, NULL, 2, 'P-CCS-0929-017', 'Enrollment Concern', '2025-09-29 15:39:28', '2025-09-29 15:39:28', '2025-09-29 15:40:09', 'completed', 1);
INSERT INTO `queues` VALUES (103, 23, NULL, 4, 'CCS-0929-020', 'Promissory Note', '2025-09-29 15:43:27', '2025-09-29 15:43:27', '2025-09-29 15:46:42', 'completed', 0);
INSERT INTO `queues` VALUES (105, 28, NULL, 2, 'CCS-0929-022', 'Tuition Payment', '2025-09-29 08:00:00', '2025-09-29 15:48:29', NULL, 'completed', 0);
INSERT INTO `queues` VALUES (106, 23, NULL, 4, 'P-CCS-0929-023', 'Document Request, doc_req:Diploma', '2025-09-29 08:00:00', '2025-09-29 15:50:08', '2025-09-29 15:50:24', 'completed', 1);
INSERT INTO `queues` VALUES (107, 21, NULL, 4, 'S NFORMATION ECHNOLO', 'Tuition Payment, Enrollment Concern', '2025-09-30 12:52:48', '2025-09-30 12:52:48', NULL, 'completed', 0);
INSERT INTO `queues` VALUES (108, 46, NULL, 4, 'BSIT-0930-002', 'Tuition Payment', '2025-09-30 12:57:27', '2025-09-30 12:57:27', NULL, 'cancelled', 0);
INSERT INTO `queues` VALUES (133, 28, NULL, 2, 'BSIT-1009-002', 'Tuition Payment, Others', '2025-10-09 14:13:53', '2025-10-09 14:13:53', '2025-10-09 14:14:06', 'completed', 0);
INSERT INTO `queues` VALUES (134, 28, NULL, 2, 'BSIT-1009-003', 'Tuition Payment', '2025-10-09 14:16:04', '2025-10-09 14:16:04', NULL, 'completed', 0);
INSERT INTO `queues` VALUES (139, 21, NULL, 1, 'GEN-1022-004', 'Tuition Payment', '2025-10-22 09:30:00', '2025-10-22 22:24:31', '2025-10-22 22:24:41', 'completed', 0);
INSERT INTO `queues` VALUES (149, 56, NULL, 1, 'GEN-1023-001', 'Tuition Payment, Enrollment Concern', '2025-10-23 08:00:00', '2025-10-23 16:48:10', '2025-10-23 16:48:33', 'completed', 0);
INSERT INTO `queues` VALUES (150, 56, NULL, 1, 'GEN-1023-002', 'Enrollment Concern, Promissory Note', '2025-10-23 08:30:00', '2025-10-23 16:49:21', '2025-10-23 17:01:57', 'completed', 0);
INSERT INTO `queues` VALUES (151, 56, NULL, 1, 'GEN-1024-001', 'Tuition Payment', '2025-10-24 08:00:00', '2025-10-24 12:38:47', '2025-10-24 12:39:04', 'completed', 0);
INSERT INTO `queues` VALUES (152, 56, NULL, 1, 'GEN-1024-002', 'Tuition Payment', '2025-10-24 08:30:00', '2025-10-24 12:50:44', '2025-10-24 12:51:51', 'completed', 0);
INSERT INTO `queues` VALUES (153, 56, NULL, 1, 'GEN-1024-003', 'Enrollment Concern, Document Request, doc_req:Transcript of Records (TOR)', '2025-10-24 09:00:00', '2025-10-24 12:53:56', '2025-10-24 12:54:07', 'completed', 0);
INSERT INTO `queues` VALUES (154, 56, NULL, 1, 'P-GEN-1024-004', 'Enrollment Concern', '2025-10-24 09:30:00', '2025-10-24 12:55:08', '2025-10-24 12:55:17', 'completed', 1);
INSERT INTO `queues` VALUES (155, 56, NULL, 1, 'GEN-1024-005', 'Tuition Payment', '2025-10-25 00:00:00', '2025-10-24 13:12:40', NULL, 'completed', 0);
INSERT INTO `queues` VALUES (156, 50, NULL, 1, 'P-BSIT-1024-006', 'Tuition Payment', '2025-10-25 00:00:00', '2025-10-24 14:27:59', NULL, 'scheduled', 1);
INSERT INTO `queues` VALUES (157, 23, NULL, 1, 'BSIT-1024-007', 'Tuition Payment', '2025-10-25 00:00:00', '2025-10-24 14:59:51', NULL, 'completed', 0);
INSERT INTO `queues` VALUES (158, 56, NULL, 1, 'GEN-1024-008', 'Tuition Payment', '2025-10-26 00:00:00', '2025-10-24 15:02:07', NULL, 'completed', 0);
INSERT INTO `queues` VALUES (159, 28, NULL, 1, 'BSIT-1024-009', 'Tuition Payment', '2025-10-25 00:00:00', '2025-10-24 15:06:05', NULL, 'completed', 0);
INSERT INTO `queues` VALUES (160, 28, NULL, 1, 'BSIT-1024-010', 'Tuition Payment', '2025-10-25 00:00:00', '2025-10-24 16:08:31', NULL, 'completed', 0);
INSERT INTO `queues` VALUES (161, 28, NULL, 1, 'BSIT-1024-011', 'Tuition Payment', '2025-10-25 00:00:00', '2025-10-24 16:10:31', NULL, 'completed', 0);
INSERT INTO `queues` VALUES (162, 56, NULL, 1, 'GEN-1024-012', 'Tuition Payment', '2025-10-24 10:00:00', '2025-10-24 17:05:40', NULL, 'completed', 0);
INSERT INTO `queues` VALUES (163, 56, NULL, 1, 'GEN-1025-001', 'Tuition Payment', '2025-10-25 11:03:03', '2025-10-25 11:03:03', '2025-10-25 11:03:25', 'completed', 0);
INSERT INTO `queues` VALUES (164, 28, NULL, 1, 'BSIT-1025-002', 'Tuition Payment', '2025-10-25 11:05:05', '2025-10-25 11:05:05', '2025-10-25 11:33:14', 'completed', 0);
INSERT INTO `queues` VALUES (165, 56, NULL, 1, 'GEN-1025-003', 'Tuition Payment', '2025-10-26 00:00:00', '2025-10-25 11:33:44', NULL, 'expired', 1);
INSERT INTO `queues` VALUES (166, 56, NULL, 3, 'GEN-1025-004', 'Tuition Payment', '2025-10-25 12:09:45', '2025-10-25 12:09:45', '2025-10-25 12:09:54', 'no-show', 0);
INSERT INTO `queues` VALUES (167, 28, NULL, 3, 'BSIT-1025-005', 'Tuition Payment', '2025-10-25 12:10:24', '2025-10-25 12:10:24', '2025-10-25 12:10:27', 'completed', 0);
INSERT INTO `queues` VALUES (168, 56, NULL, 3, 'GEN-1025-006', 'Promissory Note', '2025-10-25 12:11:01', '2025-10-25 12:11:01', '2025-10-25 12:11:10', 'completed', 0);
INSERT INTO `queues` VALUES (169, 23, NULL, 3, 'BSIT-1025-007', 'Enrollment Concern', '2025-10-25 12:11:47', '2025-10-25 12:11:47', '2025-10-25 12:11:51', 'completed', 0);
INSERT INTO `queues` VALUES (170, 23, NULL, 3, 'BSIT-1025-008', 'Tuition Payment', '2025-10-25 12:16:46', '2025-10-25 12:16:46', '2025-10-25 12:16:56', 'completed', 0);
INSERT INTO `queues` VALUES (171, 56, NULL, 1, 'GEN-1025-009', 'Tuition Payment', '2025-10-25 19:57:16', '2025-10-25 19:57:16', '2025-10-25 19:57:26', 'completed', 0);
INSERT INTO `queues` VALUES (172, 56, NULL, 1, 'GEN-1027-001', 'Tuition Payment', '2025-10-27 08:00:00', '2025-10-27 18:11:50', '2025-10-27 18:12:09', 'completed', 0);
INSERT INTO `queues` VALUES (173, 21, NULL, 1, 'BSIT-1027-002', 'Document Request, doc_req:Transcript of Records (TOR)', '2025-10-28 00:00:00', '2025-10-27 18:16:08', NULL, 'completed', 0);
INSERT INTO `queues` VALUES (174, 39, NULL, 1, 'GEN-1027-003', 'Tuition Payment', '2025-10-27 08:30:00', '2025-10-27 18:50:26', '2025-10-27 18:50:35', 'completed', 0);
INSERT INTO `queues` VALUES (175, 56, NULL, 2, 'GEN-1027-004', 'Tuition Payment', '2025-10-27 08:00:00', '2025-10-27 18:54:58', '2025-10-27 18:55:04', 'completed', 0);
INSERT INTO `queues` VALUES (176, 56, NULL, 1, 'GEN-1027-005', 'Enrollment Concern', '2025-11-07 00:00:00', '2025-10-27 20:12:14', NULL, 'completed', 0);
INSERT INTO `queues` VALUES (177, 56, NULL, 1, 'P-GEN-1028-001', 'Tuition Payment', '2025-10-29 00:00:00', '2025-10-28 11:11:41', NULL, 'completed', 1);
INSERT INTO `queues` VALUES (178, 56, NULL, 1, 'GEN-1028-002', 'Clearance Signing', '2025-10-28 08:00:00', '2025-10-28 12:22:53', '2025-10-28 12:23:01', 'expired', 0);
INSERT INTO `queues` VALUES (179, 56, NULL, 1, 'GEN-1028-003', 'Clearance Signing', '2025-10-28 08:30:00', '2025-10-28 12:24:16', '2025-10-28 12:27:03', 'completed', 0);
INSERT INTO `queues` VALUES (180, 23, NULL, 1, 'GEN-1028-004', 'Clearance Signing', '2025-10-28 09:00:00', '2025-10-28 12:27:57', '2025-10-28 12:28:04', 'completed', 0);

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
-- Records of security_audit_log
-- ----------------------------

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
-- Records of settings
-- ----------------------------
INSERT INTO `settings` VALUES ('LockoutDurationMinutes', '15');
INSERT INTO `settings` VALUES ('MaxLoginAttempts', '5');

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
-- Records of student_guardian_map
-- ----------------------------

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
-- Records of students
-- ----------------------------
INSERT INTO `students` VALUES (1, '1111-11', 'ESCUDERO', 'ROSALYN', NULL, 'BS Computer Science', NULL, 'Rosalyn_Escudero_sh@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 15:45:57');
INSERT INTO `students` VALUES (21, 'C2006-23', 'ABRIO', 'DRIAN EUIJAY', NULL, 'BS Information Technology', '3rd Year', 'C2006-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (23, 'C1118-23', 'ATOG', 'SEAN', NULL, 'BS Information Technology', '3rd Year', 'C1118-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (24, 'C2202-23', 'BUSTRILLO', 'JASON', NULL, 'BS Information Technology', '3rd Year', 'C2202-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (25, 'C1988-23', 'CASAKIT', 'BEATRICE', NULL, 'BS Information Technology', '3rd Year', 'C1988-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (26, 'C2008-23', 'CENARDO', 'VERNALYN', NULL, 'BS Information Technology', '3rd Year', 'C2008-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (27, 'C1092-23', 'DE CASTRO', 'PIERRE BENEDICT', NULL, 'BS Information Technology', '3rd Year', 'C1092-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (28, 'C2027-23', 'DELA CRUZ', 'JEAN ROMUALD', NULL, 'BS Information Technology', '3rd Year', 'C2027-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (29, 'C2205-23', 'DIAZ', 'REINZ DEREK', NULL, 'BS Information Technology', '3rd Year', 'C2205-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (30, 'C1076-17', 'FLOR', 'PATRICK DAE', NULL, 'BS Information Technology', '3rd Year', 'C1076-17@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (31, 'C2040-23', 'GUANZON', 'JOHNLLOYD', NULL, 'BS Information Technology', '3rd Year', 'C2040-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (32, 'C2005-23', 'GUARDIAN', 'RYMARK', NULL, 'BS Information Technology', '3rd Year', 'C2005-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (33, 'C1944-23', 'JAVIER', 'MARY JHAZMINE', NULL, 'BS Information Technology', '3rd Year', 'C1944-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (34, 'C1929-23', 'LIM', 'KIM CARLO', NULL, 'BS Information Technology', '3rd Year', 'C1929-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (35, 'C2903-23', 'LOBRICO', 'JB', NULL, 'BS Information Technology', '3rd Year', 'C2903-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (36, 'C1822-23', 'LORICO', 'NICK JAMES', NULL, 'BS Information Technology', '3rd Year', 'C1822-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (37, '1896-21', 'LUCBAN', 'RACHELLE ANNE', NULL, 'BS Information Technology', '3rd Year', '1896-21@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (38, 'C1662-24', 'MADALAG', 'MATTHEW', NULL, 'BS Information Technology', '3rd Year', 'C1662-24@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (39, 'C2097-23', 'MATIGA', 'XYRYLLE CLAIRE', NULL, 'BS Information Technology', '3rd Year', 'C2097-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (40, 'C1394-23', 'MIRANDA', 'JOHN NINO', NULL, 'BS Information Technology', '3rd Year', 'C1394-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (41, 'C1881-23', 'OBIS', 'FRANCINE MEI', NULL, 'BS Information Technology', '3rd Year', 'C1881-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (42, '1353-22', 'PAGHARI-ON', 'ANTHONY', NULL, 'BS Information Technology', '3rd Year', '1353-22@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (43, 'C1923-23', 'RAMIREZ', 'PRINCE DENZEL', NULL, 'BS Information Technology', '3rd Year', 'C1923-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (44, 'C2261-24', 'RAMONES', 'REGINA ANGELA', NULL, 'BS Information Technology', '3rd Year', 'C2261-24@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (46, 'C1949-23', 'RODRIGUEZ', 'YUAN JASPER', NULL, 'BS Information Technology', '3rd Year', 'C1949-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (47, 'C1878-23', 'SAGUBAN', 'BIANCA JEANELLE', NULL, 'BS Information Technology', '3rd Year', 'C1878-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (48, 'C1922-23', 'VICENTE', 'RONNEL JOHN', NULL, 'BS Information Technology', '3rd Year', 'C1922-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (49, 'C2057-23', 'YOUNG', 'VYANCE GABRIELLE', NULL, 'BS Information Technology', '3rd Year', 'C2057-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 07:35:51');
INSERT INTO `students` VALUES (50, '2770-22', 'PEÑARANDA', 'NATHAN GAVIN', NULL, 'BS Information Technology', '3rd Year', '2770-22@itmlyceumalabang.onmicrosoft.com', NULL, '2025-09-16 08:53:44');
INSERT INTO `students` VALUES (55, 'C1222-23', 'NOLASCO', 'KEITH ANGELO', NULL, 'BS in Information Technology', '3rd Year', '', NULL, '2025-10-23 11:01:57');
INSERT INTO `students` VALUES (56, 'C1030-23', 'RED', 'DANIEL RAFAEL', NULL, 'BS in Information Technology', '3rd Year', 'c1030-23@itmlyceumalabang.onmicrosoft.com', NULL, '2025-10-23 16:39:45');

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
-- Records of user_lockouts
-- ----------------------------
INSERT INTO `user_lockouts` VALUES (1, 'admin', 'admin', 2, 3, '2025-10-26 22:00:23', 'Multiple failed login attempts', '2025-10-26 21:55:23', 0, '172.20.48.1', '2025-10-26 21:55:23', '2025-10-26 22:00:23');
INSERT INTO `user_lockouts` VALUES (2, 'cashier1', 'cashier', 1, 3, '2025-10-26 22:16:40', 'Multiple failed login attempts', '2025-10-26 22:11:40', 0, '172.20.48.1', '2025-10-26 22:11:40', '2025-10-28 12:23:31');
INSERT INTO `user_lockouts` VALUES (3, 'admin', 'admin', 2, 3, '2025-10-26 22:17:19', 'Multiple failed login attempts', '2025-10-26 22:12:19', 0, '172.20.48.1', '2025-10-26 22:12:19', '2025-10-26 22:26:00');
INSERT INTO `user_lockouts` VALUES (4, 'admin', 'admin', 2, 3, '2025-10-27 10:05:23', 'Multiple failed login attempts', '2025-10-27 09:50:23', 0, '172.20.48.1', '2025-10-27 09:50:23', '2025-10-27 10:05:23');
INSERT INTO `user_lockouts` VALUES (5, 'admin2', 'admin', 4, 3, '2025-10-27 10:56:02', 'Multiple failed login attempts', '2025-10-27 10:51:02', 1, '172.20.48.1', '2025-10-27 10:51:02', '2025-10-27 10:51:02');

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
-- Records of users
-- ----------------------------
INSERT INTO `users` VALUES (13, 48, NULL, 'ronnel.vicente', '$2y$10$GduIvCYvA5BDVHCjqOKbRekrtZQFGn83Tup2bApm3cwh.rdocOI1u', '2025-09-16 13:23:05', '2025-09-16 13:22:49');
INSERT INTO `users` VALUES (14, 50, NULL, 'nathan.peñaranda', '$2y$10$LQb8njEYxk9y88WTVoP3e.lM08J4wI3REo9Dx4BzVf3wDIAEv74Eq', '2025-10-24 14:27:48', '2025-09-16 13:33:46');
INSERT INTO `users` VALUES (15, 39, NULL, 'xyrylle.matiga', '$2y$10$0jrKbxIsawxKnx69Ay0JTeg.985Q.8rwXgA1U4rpiSGJ55za5RzgW', '2025-09-16 13:45:26', '2025-09-16 13:45:01');
INSERT INTO `users` VALUES (18, 23, NULL, 'sean.atog', '$2b$10$H7AJn1ckRo5ihB50bVsde.F0KErFwKYEypVuB0c/d4fmciu4m5zZW', '2025-10-24 14:59:38', '2025-09-16 15:14:44');
INSERT INTO `users` VALUES (20, 46, NULL, 'yuan.rodriguez', '$2y$10$Zfw8jsbG.9pNzCXUICnpvO0BmkD6ocwvNYJonyrqrtGpUfK3nUV4y', '2025-10-27 20:52:57', '2025-09-17 17:34:39');
INSERT INTO `users` VALUES (25, 35, NULL, 'jb.lobrico', '$2y$10$ZlshM.p7C/dGUrG.x6.DSO8jJogmbWpkKeMk54dQAiSZNbAatniF.', '2025-09-29 15:42:44', '2025-09-29 15:41:32');
INSERT INTO `users` VALUES (31, 56, NULL, 'daniel.red', '$2y$10$5IQxDjfj62kZD9jfYp7EU.xbAatSll.WbpQeLSrccDLu.6KGVPOEO', '2025-10-28 11:59:55', '2025-10-24 09:00:27');
INSERT INTO `users` VALUES (33, 28, NULL, 'jean.dela cruz', '$2b$10$669TFk4diNvm8npYC5A43..tOm4FaDuz1s3RgLH3xdgP6R1n6goWK', '2025-10-24 16:08:09', '2025-10-24 13:07:57');

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
-- Records of visitors
-- ----------------------------
INSERT INTO `visitors` VALUES (1, 'Daniel Red', 'technogaming106@gmail.com', '2025-09-25 09:24:14');
INSERT INTO `visitors` VALUES (2, 'Daniel Red', 'danred106@gmail.com', '2025-09-25 09:30:33');
INSERT INTO `visitors` VALUES (3, 'Jhiro Dela Cruz', 'loa.bsitoutreach.s0015@gmail.com', '2025-09-26 10:25:32');
INSERT INTO `visitors` VALUES (4, 'Daniel Red', 'technogaming106@gmail.com', '2025-09-27 12:30:56');
INSERT INTO `visitors` VALUES (5, 'Daniel Red', 'danred106@gmail.com', '2025-09-27 12:36:28');
INSERT INTO `visitors` VALUES (6, 'Sean Yzer', 'Seanyzer26@gmail.com', '2025-09-29 15:47:44');

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
