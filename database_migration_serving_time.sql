-- Database Migration Script for Serving Time Tracking
-- Execute these statements manually on your MySQL database

-- Add completed_at field to track when queue service is completed
ALTER TABLE `queues` 
ADD COLUMN `completed_at` timestamp NULL DEFAULT NULL AFTER `called_at`;

-- Add index for better query performance on completed_at
ALTER TABLE `queues` 
ADD INDEX `idx_completed_at` (`completed_at` ASC);

-- Optional: Add a computed/virtual column for serving_duration (MySQL 5.7+)
-- This calculates the duration in seconds between called_at and completed_at
-- Uncomment the line below if you want a computed column:
-- ALTER TABLE `queues` ADD COLUMN `serving_duration_seconds` INT GENERATED ALWAYS AS (TIMESTAMPDIFF(SECOND, called_at, completed_at)) STORED;

-- Verify the changes
DESCRIBE `queues`;
