/*
 Navicat Premium Data Transfer

 Source Server         : mysql
 Source Server Type    : MySQL
 Source Server Version : 50722
 Source Host           : localhost:3306
 Source Schema         : chatshow

 Target Server Type    : MySQL
 Target Server Version : 50722
 File Encoding         : 65001

 Date: 22/06/2018 17:56:25
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for chathis
-- ----------------------------
DROP TABLE IF EXISTS `chathis`;
CREATE TABLE `chathis`  (
  `UID1` int(11) NULL DEFAULT NULL COMMENT '发起消息的用户',
  `UID2` int(11) NULL DEFAULT NULL COMMENT '接受消息的用户',
  `isread` int(1) NULL DEFAULT NULL COMMENT '消息是否已读',
  `Sendtime` datetime(0) NULL DEFAULT NULL COMMENT '消息发送时间',
  `Sendwords` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '消息内容'
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of chathis
-- ----------------------------
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-14 22:13:03', '1234');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-14 22:13:38', '5555');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-16 09:11:23', '214');
INSERT INTO `chathis` VALUES (2, 1, 1, '2018-05-16 09:13:42', '123');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-16 09:13:45', '555');
INSERT INTO `chathis` VALUES (2, 1, 1, '2018-05-16 09:44:03', '2134');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-22 16:15:52', '123');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-22 16:16:03', '555');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-22 16:19:18', '123');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-22 16:22:02', '123');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-22 16:22:09', '555');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-22 16:22:18', '456');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-22 16:30:03', '5');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-22 16:30:08', '123');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-22 16:31:55', '5');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-22 16:37:56', '45');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-22 16:38:05', '5');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-22 20:21:22', '5');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-22 20:29:49', '12');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-22 20:29:55', '4');
INSERT INTO `chathis` VALUES (2, 1, 1, '2018-05-22 23:04:33', '4');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-22 23:04:43', '5');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-22 23:04:48', '5');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-22 23:08:10', '5');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-22 23:08:17', '4');
INSERT INTO `chathis` VALUES (2, 1, 1, '2018-05-22 23:08:19', '5');
INSERT INTO `chathis` VALUES (2, 1, 1, '2018-05-22 23:08:23', 'd');
INSERT INTO `chathis` VALUES (2, 1, 1, '2018-05-23 10:43:47', '55');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-23 10:44:09', 'f');
INSERT INTO `chathis` VALUES (1, 2, 1, '2018-05-23 10:44:13', 'f');
INSERT INTO `chathis` VALUES (3, 2, 1, '2018-06-11 22:10:31', '123');
INSERT INTO `chathis` VALUES (3, 2, 1, '2018-06-11 22:10:47', '6');
INSERT INTO `chathis` VALUES (2, 5, 1, '2018-06-20 21:54:11', '1');
INSERT INTO `chathis` VALUES (6, 2, 1, '2018-06-20 22:38:58', '555');
INSERT INTO `chathis` VALUES (5, 2, 1, '2018-06-21 01:35:23', '5');

-- ----------------------------
-- Table structure for frdreq
-- ----------------------------
DROP TABLE IF EXISTS `frdreq`;
CREATE TABLE `frdreq`  (
  `UID1` int(11) NULL DEFAULT NULL COMMENT '发起好友请求的用户UID',
  `UID2` int(11) NULL DEFAULT NULL COMMENT '目标用户UID',
  `expgroup` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '想要将好友放入的分组'
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for friends
-- ----------------------------
DROP TABLE IF EXISTS `friends`;
CREATE TABLE `friends`  (
  `UID1` int(11) NOT NULL COMMENT '用户的UID',
  `UID2` int(11) NULL DEFAULT NULL COMMENT '用户的好友UID',
  `groups` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '该好友在该用户的分组'
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of friends
-- ----------------------------
INSERT INTO `friends` VALUES (1, 3, '我的好友');
INSERT INTO `friends` VALUES (2, 4, '我的好友');
INSERT INTO `friends` VALUES (4, 2, '我的好友');
INSERT INTO `friends` VALUES (5, 2, '我的好友');
INSERT INTO `friends` VALUES (2, 5, '我的好友');
INSERT INTO `friends` VALUES (2, 6, '我的好友');
INSERT INTO `friends` VALUES (6, 2, '我的好友');

-- ----------------------------
-- Table structure for groupchathis
-- ----------------------------
DROP TABLE IF EXISTS `groupchathis`;
CREATE TABLE `groupchathis`  (
  `GID` int(11) NULL DEFAULT NULL COMMENT '群GID',
  `UID` int(11) NULL DEFAULT NULL COMMENT '发送消息的UID',
  `Sendtime` datetime(0) NULL DEFAULT NULL COMMENT '发送时间',
  `Sendwords` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '消息内容'
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of groupchathis
-- ----------------------------
INSERT INTO `groupchathis` VALUES (1, 2, '2018-05-09 08:41:40', '231');
INSERT INTO `groupchathis` VALUES (1, 2, '2018-06-09 08:42:03', '222');
INSERT INTO `groupchathis` VALUES (1, 2, '2018-06-09 08:44:56', '8888');
INSERT INTO `groupchathis` VALUES (1, 2, '2018-06-11 22:15:44', '2');
INSERT INTO `groupchathis` VALUES (1, 2, '2018-06-11 22:17:34', '555');
INSERT INTO `groupchathis` VALUES (1, 2, '2018-06-11 22:19:00', '5');
INSERT INTO `groupchathis` VALUES (1, 3, '2018-06-11 22:19:13', '6');
INSERT INTO `groupchathis` VALUES (1, 2, '2018-06-11 22:19:14', '66');
INSERT INTO `groupchathis` VALUES (1, 3, '2018-06-11 22:31:34', '123');
INSERT INTO `groupchathis` VALUES (1, 3, '2018-06-11 22:31:39', '123');
INSERT INTO `groupchathis` VALUES (1, 3, '2018-06-11 22:32:20', '555');
INSERT INTO `groupchathis` VALUES (1, 3, '2018-06-11 22:32:25', '123');
INSERT INTO `groupchathis` VALUES (1, 2, '2018-06-11 22:33:14', '5');
INSERT INTO `groupchathis` VALUES (1, 3, '2018-06-11 22:33:25', '5');
INSERT INTO `groupchathis` VALUES (1, 2, '2018-06-11 22:33:32', '4');
INSERT INTO `groupchathis` VALUES (1, 3, '2018-06-11 22:33:40', '5');
INSERT INTO `groupchathis` VALUES (1, 2, '2018-06-11 22:33:44', '45');
INSERT INTO `groupchathis` VALUES (1, 2, '2018-06-11 22:33:47', '5');
INSERT INTO `groupchathis` VALUES (5, 2, '2018-06-16 09:53:20', 's');
INSERT INTO `groupchathis` VALUES (1, 5, '2018-06-20 22:43:19', '1');

-- ----------------------------
-- Table structure for groupmembers
-- ----------------------------
DROP TABLE IF EXISTS `groupmembers`;
CREATE TABLE `groupmembers`  (
  `GID` int(11) NULL DEFAULT NULL COMMENT '群组的GID',
  `UID` int(11) NULL DEFAULT NULL COMMENT '群员的UID',
  `auth` int(1) NULL DEFAULT NULL COMMENT '群员的权限',
  `jointime` datetime(0) NULL DEFAULT NULL COMMENT '加入时间',
  `closetime` datetime(0) NULL DEFAULT NULL COMMENT '关闭群聊窗口的时间',
  `G_group` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '群聊分组'
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of groupmembers
-- ----------------------------
INSERT INTO `groupmembers` VALUES (1, 2, 0, '2018-05-22 15:46:59', '2018-06-20 22:43:52', '常用');
INSERT INTO `groupmembers` VALUES (4, 5, 0, '2018-06-20 21:51:01', '2018-06-20 21:51:01', '我的群');
INSERT INTO `groupmembers` VALUES (1, 5, 2, '2018-06-20 22:10:40', '2018-06-20 22:10:40', '我的群');

-- ----------------------------
-- Table structure for groupreq
-- ----------------------------
DROP TABLE IF EXISTS `groupreq`;
CREATE TABLE `groupreq`  (
  `GID` int(11) NOT NULL COMMENT '群的GID',
  `UID` int(11) NULL DEFAULT NULL COMMENT '申请入群的UID',
  `expgroup` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '预定加入的group名'
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for groups
-- ----------------------------
DROP TABLE IF EXISTS `groups`;
CREATE TABLE `groups`  (
  `GID` int(11) NOT NULL AUTO_INCREMENT COMMENT '群组唯一标识符',
  `Groupname` varchar(24) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '群组的名称',
  `CreatorUID` int(11) NULL DEFAULT NULL COMMENT '群主UID',
  `Groupsine` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '群简介',
  PRIMARY KEY (`GID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 5 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of groups
-- ----------------------------
INSERT INTO `groups` VALUES (1, '1号群5', 2, '55555');
INSERT INTO `groups` VALUES (2, '2号群', 3, '二个群聊');
INSERT INTO `groups` VALUES (3, '3号群', 6, '');
INSERT INTO `groups` VALUES (4, 'ysu1', 5, '123');

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user`  (
  `UID` int(11) NOT NULL AUTO_INCREMENT COMMENT '用户唯一标识符',
  `Account` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '用户的账号',
  `Password` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL COMMENT '密码',
  `Username` varchar(24) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '用户的昵称',
  `Sign` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '用户的自我介绍',
  `Groups` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '用户的分组列表',
  `G_groups` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL COMMENT '用户的群分组列表',
  PRIMARY KEY (`UID`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES (1, 'root', 'root', 'root', NULL, '1;', '1;');
INSERT INTO `user` VALUES (2, '555', '123', 'ppp2135', '我是2号用户5553', '我的好友;家人;', '我的群;常用;');
INSERT INTO `user` VALUES (3, '789', '123', 'acc', NULL, '我的好友;', '我的群;');
INSERT INTO `user` VALUES (4, '4', '4', '555', NULL, '我的好友;', '我的群;');
INSERT INTO `user` VALUES (5, '5', '5', 'xiaoming', '', '我的好友;', '我的群;');
INSERT INTO `user` VALUES (6, '6', '6', '6', NULL, '我的好友;', '我的群;');

SET FOREIGN_KEY_CHECKS = 1;
